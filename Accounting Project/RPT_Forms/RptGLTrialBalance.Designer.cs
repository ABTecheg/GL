using System;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    partial class RptGLTrialBalance
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_AccountNumber1 = new System.Windows.Forms.MaskedTextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbsummary = new System.Windows.Forms.RadioButton();
            this.rdbdetail = new System.Windows.Forms.RadioButton();
            this.txt_DepartmentCode = new System.Windows.Forms.MaskedTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_from);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 75);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Ending";
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
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.txt_DepartmentCode);
            this.groupBox2.Controls.Add(this.txt_AccountNumber1);
            this.groupBox2.Location = new System.Drawing.Point(15, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 138);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Range";
            // 
            // txt_AccountNumber1
            // 
            this.txt_AccountNumber1.Location = new System.Drawing.Point(29, 51);
            this.txt_AccountNumber1.Name = "txt_AccountNumber1";
            this.txt_AccountNumber1.PromptChar = '%';
            this.txt_AccountNumber1.Size = new System.Drawing.Size(131, 20);
            this.txt_AccountNumber1.TabIndex = 24;
            this.txt_AccountNumber1.DoubleClick += new System.EventHandler(this.txt_AccountNumber1_DoubleClick);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(36, 329);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 34;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbsummary);
            this.groupBox3.Controls.Add(this.rdbdetail);
            this.groupBox3.Location = new System.Drawing.Point(12, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 73);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Options";
            // 
            // rdbsummary
            // 
            this.rdbsummary.AutoSize = true;
            this.rdbsummary.Location = new System.Drawing.Point(24, 42);
            this.rdbsummary.Name = "rdbsummary";
            this.rdbsummary.Size = new System.Drawing.Size(139, 17);
            this.rdbsummary.TabIndex = 2;
            this.rdbsummary.TabStop = true;
            this.rdbsummary.Text = "Trial Balance (Summary)";
            this.rdbsummary.UseVisualStyleBackColor = true;
            // 
            // rdbdetail
            // 
            this.rdbdetail.AutoSize = true;
            this.rdbdetail.Location = new System.Drawing.Point(24, 19);
            this.rdbdetail.Name = "rdbdetail";
            this.rdbdetail.Size = new System.Drawing.Size(123, 17);
            this.rdbdetail.TabIndex = 0;
            this.rdbdetail.TabStop = true;
            this.rdbdetail.Text = "Trial Balance (Detail)";
            this.rdbdetail.UseVisualStyleBackColor = true;
            // 
            // txt_DepartmentCode
            // 
            this.txt_DepartmentCode.Location = new System.Drawing.Point(29, 102);
            this.txt_DepartmentCode.Name = "txt_DepartmentCode";
            this.txt_DepartmentCode.PromptChar = '%';
            this.txt_DepartmentCode.Size = new System.Drawing.Size(131, 20);
            this.txt_DepartmentCode.TabIndex = 24;
            this.txt_DepartmentCode.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txt_DepartmentCode_MaskInputRejected);
            this.txt_DepartmentCode.DoubleClick += new System.EventHandler(this.txt_DepartmentCode_DoubleClick_1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 17);
            this.radioButton1.TabIndex = 26;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Account";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 79);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(80, 17);
            this.radioButton2.TabIndex = 27;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Department";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // RptGLTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 387);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RptGLTrialBalance";
            this.Text = "G/L Trial Balance";
            this.Load += new System.EventHandler(this.RptGLTrialBalance_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        private void txt_DepartmentCode_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox txt_AccountNumber1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbsummary;
        private System.Windows.Forms.RadioButton rdbdetail;
        private System.Windows.Forms.MaskedTextBox txt_DepartmentCode;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}