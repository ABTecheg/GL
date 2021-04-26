namespace Accounting_GeneralLedger {
    partial class Rpt_Generate_Report {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rpt_Generate_Report));
            this.lblFiscalPeriod = new System.Windows.Forms.Label();
            this.cmbFiscalPeriod = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFiscalPeriod
            // 
            this.lblFiscalPeriod.AutoSize = true;
            this.lblFiscalPeriod.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiscalPeriod.Location = new System.Drawing.Point(34, 20);
            this.lblFiscalPeriod.Name = "lblFiscalPeriod";
            this.lblFiscalPeriod.Size = new System.Drawing.Size(91, 16);
            this.lblFiscalPeriod.TabIndex = 7;
            this.lblFiscalPeriod.Text = "Fiscal Period";
            // 
            // cmbFiscalPeriod
            // 
            this.cmbFiscalPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiscalPeriod.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiscalPeriod.FormattingEnabled = true;
            this.cmbFiscalPeriod.Location = new System.Drawing.Point(131, 17);
            this.cmbFiscalPeriod.Name = "cmbFiscalPeriod";
            this.cmbFiscalPeriod.Size = new System.Drawing.Size(180, 24);
            this.cmbFiscalPeriod.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Arial Narrow", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(205, 57);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 46);
            this.btnExit.TabIndex = 51;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(37, 57);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(149, 46);
            this.btnReport.TabIndex = 52;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // Rpt_Generate_Report
            // 
            this.AcceptButton = this.btnReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(353, 122);
            this.ControlBox = false;
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblFiscalPeriod);
            this.Controls.Add(this.cmbFiscalPeriod);
            this.Name = "Rpt_Generate_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Rpt_Generate_Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiscalPeriod;
        private System.Windows.Forms.ComboBox cmbFiscalPeriod;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReport;
    }
}