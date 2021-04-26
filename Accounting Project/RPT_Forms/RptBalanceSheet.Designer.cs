namespace Accounting_GeneralLedger
{
    partial class RptBalanceSheet
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdT = new System.Windows.Forms.RadioButton();
            this.rdbtraditional = new System.Windows.Forms.RadioButton();
            this.rdbstandard = new System.Windows.Forms.RadioButton();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbNeg = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chklang = new System.Windows.Forms.CheckBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdT);
            this.groupBox3.Controls.Add(this.rdbtraditional);
            this.groupBox3.Controls.Add(this.rdbstandard);
            this.groupBox3.Location = new System.Drawing.Point(230, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 92);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Type";
            // 
            // rdT
            // 
            this.rdT.AutoSize = true;
            this.rdT.Location = new System.Drawing.Point(24, 65);
            this.rdT.Name = "rdT";
            this.rdT.Size = new System.Drawing.Size(111, 17);
            this.rdT.TabIndex = 3;
            this.rdT.TabStop = true;
            this.rdT.Text = "Balance Sheet (T)";
            this.rdT.UseVisualStyleBackColor = true;
            // 
            // rdbtraditional
            // 
            this.rdbtraditional.AutoSize = true;
            this.rdbtraditional.Location = new System.Drawing.Point(24, 42);
            this.rdbtraditional.Name = "rdbtraditional";
            this.rdbtraditional.Size = new System.Drawing.Size(147, 17);
            this.rdbtraditional.TabIndex = 2;
            this.rdbtraditional.TabStop = true;
            this.rdbtraditional.Text = "Traditional Balance Sheet";
            this.rdbtraditional.UseVisualStyleBackColor = true;
            // 
            // rdbstandard
            // 
            this.rdbstandard.AutoSize = true;
            this.rdbstandard.Location = new System.Drawing.Point(24, 19);
            this.rdbstandard.Name = "rdbstandard";
            this.rdbstandard.Size = new System.Drawing.Size(141, 17);
            this.rdbstandard.TabIndex = 0;
            this.rdbstandard.TabStop = true;
            this.rdbstandard.Text = "Standard Balance Sheet";
            this.rdbstandard.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(254, 122);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 39;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_from);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 75);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balance Sheet Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "IN";
            // 
            // dtp_from
            // 
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(68, 28);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(95, 20);
            this.dtp_from.TabIndex = 32;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbNeg);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 48);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Format";
            // 
            // cmbNeg
            // 
            this.cmbNeg.FormattingEnabled = true;
            this.cmbNeg.Items.AddRange(new object[] {
            "-123",
            "(123)"});
            this.cmbNeg.Location = new System.Drawing.Point(96, 16);
            this.cmbNeg.Name = "cmbNeg";
            this.cmbNeg.Size = new System.Drawing.Size(67, 21);
            this.cmbNeg.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "NegativeFormat";
            // 
            // chklang
            // 
            this.chklang.AutoSize = true;
            this.chklang.Location = new System.Drawing.Point(25, 149);
            this.chklang.Name = "chklang";
            this.chklang.Size = new System.Drawing.Size(146, 17);
            this.chklang.TabIndex = 44;
            this.chklang.Text = "Print By Arabic Language";
            this.chklang.UseVisualStyleBackColor = true;
            // 
            // RptBalanceSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 189);
            this.Controls.Add(this.chklang);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RptBalanceSheet";
            this.Text = "BalanceSheet";
            this.Load += new System.EventHandler(this.RptBalanceSheet_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbtraditional;
        private System.Windows.Forms.RadioButton rdbstandard;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNeg;
        private System.Windows.Forms.RadioButton rdT;
        private System.Windows.Forms.CheckBox chklang;
    }
}