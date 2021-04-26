namespace Accounting_GeneralLedger {
    partial class reportGenerator {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cbFiscalYear = new System.Windows.Forms.ComboBox();
            this.cbFiscalPeriod = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAnalysis = new System.Windows.Forms.RadioButton();
            this.rbIncomeMenu = new System.Windows.Forms.RadioButton();
            this.rbMoneyState = new System.Windows.Forms.RadioButton();
            this.rbRevision = new System.Windows.Forms.RadioButton();
            this.rbTrialBalance = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.lblFiscalYear = new System.Windows.Forms.Label();
            this.lblFiscalPeriod = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.rbPosted = new System.Windows.Forms.RadioButton();
            this.rbUnPosted = new System.Windows.Forms.RadioButton();
            this.txtFromAccount = new System.Windows.Forms.TextBox();
            this.txtToAccount = new System.Windows.Forms.TextBox();
            this.lblFromAccount = new System.Windows.Forms.Label();
            this.lblToAccount = new System.Windows.Forms.Label();
            this.btnFrom = new System.Windows.Forms.Button();
            this.btnTo = new System.Windows.Forms.Button();
            this.lblFiscalPeriod2 = new System.Windows.Forms.Label();
            this.cbFiscalPeriod2 = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbFiscalYear
            // 
            this.cbFiscalYear.FormattingEnabled = true;
            this.cbFiscalYear.Location = new System.Drawing.Point(150, 138);
            this.cbFiscalYear.Name = "cbFiscalYear";
            this.cbFiscalYear.Size = new System.Drawing.Size(135, 21);
            this.cbFiscalYear.TabIndex = 0;
            // 
            // cbFiscalPeriod
            // 
            this.cbFiscalPeriod.FormattingEnabled = true;
            this.cbFiscalPeriod.Location = new System.Drawing.Point(78, 180);
            this.cbFiscalPeriod.Name = "cbFiscalPeriod";
            this.cbFiscalPeriod.Size = new System.Drawing.Size(131, 21);
            this.cbFiscalPeriod.TabIndex = 1;
            this.cbFiscalPeriod.SelectedIndexChanged += new System.EventHandler(this.cbFiscalPeriod_SelectedIndexChanged);
            this.cbFiscalPeriod.DropDown += new System.EventHandler(this.cbFiscalPeriod_DropDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAnalysis);
            this.groupBox1.Controls.Add(this.rbIncomeMenu);
            this.groupBox1.Controls.Add(this.rbMoneyState);
            this.groupBox1.Controls.Add(this.rbRevision);
            this.groupBox1.Controls.Add(this.rbTrialBalance);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Type";
            // 
            // rbAnalysis
            // 
            this.rbAnalysis.AutoSize = true;
            this.rbAnalysis.Location = new System.Drawing.Point(197, 63);
            this.rbAnalysis.Name = "rbAnalysis";
            this.rbAnalysis.Size = new System.Drawing.Size(134, 17);
            this.rbAnalysis.TabIndex = 6;
            this.rbAnalysis.TabStop = true;
            this.rbAnalysis.Text = " Õ·Ì· Õ”«» «” «– ⁄«„";
            this.rbAnalysis.UseVisualStyleBackColor = true;
            this.rbAnalysis.CheckedChanged += new System.EventHandler(this.rbAnalysis_CheckedChanged);
            // 
            // rbIncomeMenu
            // 
            this.rbIncomeMenu.AutoSize = true;
            this.rbIncomeMenu.Location = new System.Drawing.Point(197, 40);
            this.rbIncomeMenu.Name = "rbIncomeMenu";
            this.rbIncomeMenu.Size = new System.Drawing.Size(79, 17);
            this.rbIncomeMenu.TabIndex = 5;
            this.rbIncomeMenu.TabStop = true;
            this.rbIncomeMenu.Text = "ﬁ«∆„… «·œŒ·";
            this.rbIncomeMenu.UseVisualStyleBackColor = true;
            this.rbIncomeMenu.CheckedChanged += new System.EventHandler(this.rbIncomeMenu_CheckedChanged);
            // 
            // rbMoneyState
            // 
            this.rbMoneyState.AutoSize = true;
            this.rbMoneyState.Location = new System.Drawing.Point(197, 16);
            this.rbMoneyState.Name = "rbMoneyState";
            this.rbMoneyState.Size = new System.Drawing.Size(86, 17);
            this.rbMoneyState.TabIndex = 4;
            this.rbMoneyState.TabStop = true;
            this.rbMoneyState.Text = "«·„—ﬂ“ «·„«·Ì";
            this.rbMoneyState.UseVisualStyleBackColor = true;
            this.rbMoneyState.CheckedChanged += new System.EventHandler(this.rbMoneyState_CheckedChanged);
            // 
            // rbRevision
            // 
            this.rbRevision.AutoSize = true;
            this.rbRevision.Location = new System.Drawing.Point(6, 63);
            this.rbRevision.Name = "rbRevision";
            this.rbRevision.Size = new System.Drawing.Size(93, 17);
            this.rbRevision.TabIndex = 3;
            this.rbRevision.TabStop = true;
            this.rbRevision.Text = "„Ì“«‰ «·„—«Ã⁄…";
            this.rbRevision.UseVisualStyleBackColor = true;
            this.rbRevision.CheckedChanged += new System.EventHandler(this.rbRevision_CheckedChanged);
            // 
            // rbTrialBalance
            // 
            this.rbTrialBalance.AutoSize = true;
            this.rbTrialBalance.Location = new System.Drawing.Point(6, 40);
            this.rbTrialBalance.Name = "rbTrialBalance";
            this.rbTrialBalance.Size = new System.Drawing.Size(132, 17);
            this.rbTrialBalance.TabIndex = 2;
            this.rbTrialBalance.TabStop = true;
            this.rbTrialBalance.Text = "Trial Balance Summary";
            this.rbTrialBalance.UseVisualStyleBackColor = true;
            this.rbTrialBalance.CheckedChanged += new System.EventHandler(this.rbTrialBalance_CheckedChanged);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(6, 86);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(102, 17);
            this.rb2.TabIndex = 1;
            this.rb2.TabStop = true;
            this.rb2.Text = "Budget Planning";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(6, 16);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(88, 17);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.Text = "Batch Report";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.CheckedChanged += new System.EventHandler(this.rb1_CheckedChanged);
            // 
            // lblFiscalYear
            // 
            this.lblFiscalYear.AutoSize = true;
            this.lblFiscalYear.Location = new System.Drawing.Point(58, 146);
            this.lblFiscalYear.Name = "lblFiscalYear";
            this.lblFiscalYear.Size = new System.Drawing.Size(58, 13);
            this.lblFiscalYear.TabIndex = 4;
            this.lblFiscalYear.Text = "Fiscal Year";
            // 
            // lblFiscalPeriod
            // 
            this.lblFiscalPeriod.AutoSize = true;
            this.lblFiscalPeriod.Location = new System.Drawing.Point(3, 180);
            this.lblFiscalPeriod.Name = "lblFiscalPeriod";
            this.lblFiscalPeriod.Size = new System.Drawing.Size(66, 13);
            this.lblFiscalPeriod.TabIndex = 5;
            this.lblFiscalPeriod.Text = "Fiscal Period";
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(150, 265);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // rbPosted
            // 
            this.rbPosted.AutoSize = true;
            this.rbPosted.Location = new System.Drawing.Point(100, 225);
            this.rbPosted.Name = "rbPosted";
            this.rbPosted.Size = new System.Drawing.Size(58, 17);
            this.rbPosted.TabIndex = 2;
            this.rbPosted.TabStop = true;
            this.rbPosted.Text = "Posted";
            this.rbPosted.UseVisualStyleBackColor = true;
            this.rbPosted.Visible = false;
            // 
            // rbUnPosted
            // 
            this.rbUnPosted.AutoSize = true;
            this.rbUnPosted.Location = new System.Drawing.Point(285, 225);
            this.rbUnPosted.Name = "rbUnPosted";
            this.rbUnPosted.Size = new System.Drawing.Size(71, 17);
            this.rbUnPosted.TabIndex = 3;
            this.rbUnPosted.TabStop = true;
            this.rbUnPosted.Text = "UnPosted";
            this.rbUnPosted.UseVisualStyleBackColor = true;
            this.rbUnPosted.Visible = false;
            // 
            // txtFromAccount
            // 
            this.txtFromAccount.Location = new System.Drawing.Point(78, 224);
            this.txtFromAccount.Name = "txtFromAccount";
            this.txtFromAccount.Size = new System.Drawing.Size(100, 20);
            this.txtFromAccount.TabIndex = 6;
            this.txtFromAccount.Visible = false;
            // 
            // txtToAccount
            // 
            this.txtToAccount.Location = new System.Drawing.Point(287, 224);
            this.txtToAccount.Name = "txtToAccount";
            this.txtToAccount.Size = new System.Drawing.Size(100, 20);
            this.txtToAccount.TabIndex = 7;
            this.txtToAccount.Visible = false;
            // 
            // lblFromAccount
            // 
            this.lblFromAccount.AutoSize = true;
            this.lblFromAccount.Location = new System.Drawing.Point(3, 227);
            this.lblFromAccount.Name = "lblFromAccount";
            this.lblFromAccount.Size = new System.Drawing.Size(73, 13);
            this.lblFromAccount.TabIndex = 8;
            this.lblFromAccount.Text = "From Account";
            this.lblFromAccount.Visible = false;
            // 
            // lblToAccount
            // 
            this.lblToAccount.AutoSize = true;
            this.lblToAccount.Location = new System.Drawing.Point(223, 227);
            this.lblToAccount.Name = "lblToAccount";
            this.lblToAccount.Size = new System.Drawing.Size(61, 13);
            this.lblToAccount.TabIndex = 9;
            this.lblToAccount.Text = "To Account";
            this.lblToAccount.Visible = false;
            // 
            // btnFrom
            // 
            this.btnFrom.Image = global::Accounting_GeneralLedger.Properties.Resources.find;
            this.btnFrom.Location = new System.Drawing.Point(180, 221);
            this.btnFrom.Name = "btnFrom";
            this.btnFrom.Size = new System.Drawing.Size(41, 25);
            this.btnFrom.TabIndex = 3;
            this.btnFrom.UseVisualStyleBackColor = true;
            this.btnFrom.Visible = false;
            this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
            // 
            // btnTo
            // 
            this.btnTo.Image = global::Accounting_GeneralLedger.Properties.Resources.find;
            this.btnTo.Location = new System.Drawing.Point(389, 221);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(41, 25);
            this.btnTo.TabIndex = 10;
            this.btnTo.UseVisualStyleBackColor = true;
            this.btnTo.Visible = false;
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // lblFiscalPeriod2
            // 
            this.lblFiscalPeriod2.AutoSize = true;
            this.lblFiscalPeriod2.Location = new System.Drawing.Point(227, 180);
            this.lblFiscalPeriod2.Name = "lblFiscalPeriod2";
            this.lblFiscalPeriod2.Size = new System.Drawing.Size(66, 26);
            this.lblFiscalPeriod2.TabIndex = 12;
            this.lblFiscalPeriod2.Text = "Fiscal Period\r\nTo\r\n";
            // 
            // cbFiscalPeriod2
            // 
            this.cbFiscalPeriod2.FormattingEnabled = true;
            this.cbFiscalPeriod2.Location = new System.Drawing.Point(299, 180);
            this.cbFiscalPeriod2.Name = "cbFiscalPeriod2";
            this.cbFiscalPeriod2.Size = new System.Drawing.Size(131, 21);
            this.cbFiscalPeriod2.TabIndex = 11;
            this.cbFiscalPeriod2.DropDown += new System.EventHandler(this.cbFiscalPeriod2_DropDown);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(324, 273);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(65, 35);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // reportGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 348);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblFiscalPeriod2);
            this.Controls.Add(this.cbFiscalPeriod2);
            this.Controls.Add(this.btnTo);
            this.Controls.Add(this.btnFrom);
            this.Controls.Add(this.lblToAccount);
            this.Controls.Add(this.lblFromAccount);
            this.Controls.Add(this.txtToAccount);
            this.Controls.Add(this.txtFromAccount);
            this.Controls.Add(this.rbPosted);
            this.Controls.Add(this.rbUnPosted);
            this.Controls.Add(this.lblFiscalPeriod);
            this.Controls.Add(this.lblFiscalYear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.cbFiscalPeriod);
            this.Controls.Add(this.cbFiscalYear);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "reportGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reportGenerator";
            this.Load += new System.EventHandler(this.reportGenerator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFiscalYear;
        private System.Windows.Forms.ComboBox cbFiscalPeriod;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.Label lblFiscalYear;
        private System.Windows.Forms.Label lblFiscalPeriod;
        private System.Windows.Forms.RadioButton rbPosted;
        private System.Windows.Forms.RadioButton rbUnPosted;
        private System.Windows.Forms.TextBox txtFromAccount;
        private System.Windows.Forms.TextBox txtToAccount;
        private System.Windows.Forms.Label lblFromAccount;
        private System.Windows.Forms.Label lblToAccount;
        private System.Windows.Forms.RadioButton rbTrialBalance;
        private System.Windows.Forms.Button btnFrom;
        private System.Windows.Forms.Button btnTo;
        private System.Windows.Forms.Label lblFiscalPeriod2;
        private System.Windows.Forms.ComboBox cbFiscalPeriod2;
        private System.Windows.Forms.RadioButton rbRevision;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.RadioButton rbIncomeMenu;
        private System.Windows.Forms.RadioButton rbMoneyState;
        private System.Windows.Forms.RadioButton rbAnalysis;
    }
}