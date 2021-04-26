namespace Accounting_GeneralLedger {
    partial class ENDYear {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ENDYear));
            this.lblFiscalPeriod = new System.Windows.Forms.Label();
            this.cbFiscalYear = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFiscalPeriod
            // 
            this.lblFiscalPeriod.AutoSize = true;
            this.lblFiscalPeriod.Location = new System.Drawing.Point(79, 42);
            this.lblFiscalPeriod.Name = "lblFiscalPeriod";
            this.lblFiscalPeriod.Size = new System.Drawing.Size(59, 13);
            this.lblFiscalPeriod.TabIndex = 53;
            this.lblFiscalPeriod.Text = "Fiscal Year";
            // 
            // cbFiscalYear
            // 
            this.cbFiscalYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiscalYear.FormattingEnabled = true;
            this.cbFiscalYear.Location = new System.Drawing.Point(160, 39);
            this.cbFiscalYear.Name = "cbFiscalYear";
            this.cbFiscalYear.Size = new System.Drawing.Size(135, 21);
            this.cbFiscalYear.TabIndex = 52;
            this.cbFiscalYear.DropDown += new System.EventHandler(this.cbFiscalYear_DropDown);
            this.cbFiscalYear.SelectedIndexChanged += new System.EventHandler(this.cbFiscalYear_SelectedIndexChanged);
            this.cbFiscalYear.DropDownClosed += new System.EventHandler(this.cbFiscalYear_DropDownClosed);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Arial Narrow", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(216, 89);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 46);
            this.btnExit.TabIndex = 55;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.lock1;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(34, 93);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 42);
            this.btnReport.TabIndex = 54;
            this.btnReport.Text = "End Year";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(322, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 86);
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // ENDYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(455, 148);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblFiscalPeriod);
            this.Controls.Add(this.cbFiscalYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ENDYear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ENDYear";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ENDYear_FormClosed);
            this.Load += new System.EventHandler(this.ENDYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblFiscalPeriod;
        private System.Windows.Forms.ComboBox cbFiscalYear;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}