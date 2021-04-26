namespace Accounting_GeneralLedger {
    partial class rptBudgetPlanning {
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
            this.CViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CViewer1
            // 
            this.CViewer1.ActiveViewIndex = -1;
            this.CViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CViewer1.Location = new System.Drawing.Point(0, 0);
            this.CViewer1.Name = "CViewer1";
            this.CViewer1.SelectionFormula = "";
            this.CViewer1.Size = new System.Drawing.Size(578, 363);
            this.CViewer1.TabIndex = 0;
            this.CViewer1.ViewTimeSelectionFormula = "";
            // 
            // rptBudgetPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 363);
            this.Controls.Add(this.CViewer1);
            this.Name = "rptBudgetPlanning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Budget Planning Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptStandardBalanceSheet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CViewer1;
    }
}