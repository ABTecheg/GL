namespace Accounting_GeneralLedger
{
    partial class GLGeneralSetup
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
            this.txt_AccountBalanceSheet = new System.Windows.Forms.TextBox();
            this.txt_AccountIncomeStat = new System.Windows.Forms.TextBox();
            this.btn_SearchBalanceSheet = new System.Windows.Forms.Button();
            this.btn_SearchIncomeStatement = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PL Account Balance sheet";
            // 
            // txt_AccountBalanceSheet
            // 
            this.txt_AccountBalanceSheet.Location = new System.Drawing.Point(239, 38);
            this.txt_AccountBalanceSheet.Name = "txt_AccountBalanceSheet";
            this.txt_AccountBalanceSheet.Size = new System.Drawing.Size(183, 20);
            this.txt_AccountBalanceSheet.TabIndex = 1;
            // 
            // txt_AccountIncomeStat
            // 
            this.txt_AccountIncomeStat.Location = new System.Drawing.Point(239, 74);
            this.txt_AccountIncomeStat.Name = "txt_AccountIncomeStat";
            this.txt_AccountIncomeStat.Size = new System.Drawing.Size(183, 20);
            this.txt_AccountIncomeStat.TabIndex = 2;
            // 
            // btn_SearchBalanceSheet
            // 
            this.btn_SearchBalanceSheet.Location = new System.Drawing.Point(438, 36);
            this.btn_SearchBalanceSheet.Name = "btn_SearchBalanceSheet";
            this.btn_SearchBalanceSheet.Size = new System.Drawing.Size(75, 23);
            this.btn_SearchBalanceSheet.TabIndex = 3;
            this.btn_SearchBalanceSheet.Text = "Search";
            this.btn_SearchBalanceSheet.UseVisualStyleBackColor = true;
            this.btn_SearchBalanceSheet.Click += new System.EventHandler(this.btn_SearchBalanceSheet_Click);
            // 
            // btn_SearchIncomeStatement
            // 
            this.btn_SearchIncomeStatement.Location = new System.Drawing.Point(438, 71);
            this.btn_SearchIncomeStatement.Name = "btn_SearchIncomeStatement";
            this.btn_SearchIncomeStatement.Size = new System.Drawing.Size(75, 23);
            this.btn_SearchIncomeStatement.TabIndex = 4;
            this.btn_SearchIncomeStatement.Text = "Search";
            this.btn_SearchIncomeStatement.UseVisualStyleBackColor = true;
            this.btn_SearchIncomeStatement.Click += new System.EventHandler(this.btn_SearchIncomeStatement_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "PL Account Income Statement";
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(438, 129);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 6;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // GLGeneralSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(557, 164);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_SearchIncomeStatement);
            this.Controls.Add(this.btn_SearchBalanceSheet);
            this.Controls.Add(this.txt_AccountIncomeStat);
            this.Controls.Add(this.txt_AccountBalanceSheet);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GLGeneralSetup";
            this.Text = "GLGeneralSetup";
            this.Load += new System.EventHandler(this.GLGeneralSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_AccountBalanceSheet;
        private System.Windows.Forms.TextBox txt_AccountIncomeStat;
        private System.Windows.Forms.Button btn_SearchBalanceSheet;
        private System.Windows.Forms.Button btn_SearchIncomeStatement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Ok;
    }
}