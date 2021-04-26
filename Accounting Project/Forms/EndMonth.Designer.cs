namespace Accounting_GeneralLedger {
    partial class EndMonth {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndMonth));
            this.lblFiscalPeriod = new System.Windows.Forms.Label();
            this.cbFiscalPeriod = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFiscalPeriod
            // 
            this.lblFiscalPeriod.AutoSize = true;
            this.lblFiscalPeriod.Location = new System.Drawing.Point(88, 39);
            this.lblFiscalPeriod.Name = "lblFiscalPeriod";
            this.lblFiscalPeriod.Size = new System.Drawing.Size(67, 13);
            this.lblFiscalPeriod.TabIndex = 7;
            this.lblFiscalPeriod.Text = "Fiscal Period";
            // 
            // cbFiscalPeriod
            // 
            this.cbFiscalPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiscalPeriod.FormattingEnabled = true;
            this.cbFiscalPeriod.Location = new System.Drawing.Point(160, 36);
            this.cbFiscalPeriod.Name = "cbFiscalPeriod";
            this.cbFiscalPeriod.Size = new System.Drawing.Size(132, 21);
            this.cbFiscalPeriod.TabIndex = 6;
            this.cbFiscalPeriod.SelectedIndexChanged += new System.EventHandler(this.cbFiscalPeriod_SelectedIndexChanged);
            this.cbFiscalPeriod.DropDownClosed += new System.EventHandler(this.cbFiscalPeriod_DropDownClosed);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Arial Narrow", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(197, 82);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 46);
            this.btnExit.TabIndex = 51;
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
            this.btnReport.Location = new System.Drawing.Point(19, 82);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 42);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "End Period";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(339, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 86);
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // EndMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(455, 146);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblFiscalPeriod);
            this.Controls.Add(this.cbFiscalPeriod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EndMonth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "End Period";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EndMonth_FormClosed);
            this.Load += new System.EventHandler(this.EndMonth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiscalPeriod;
        private System.Windows.Forms.ComboBox cbFiscalPeriod;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}