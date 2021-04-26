namespace Accounting_GeneralLedger
{
    partial class RPTAPDestributionFrm
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
            this.btnReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(19, 100);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 31;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "From";
            // 
            // dtp_to
            // 
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to.Location = new System.Drawing.Point(69, 53);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(95, 20);
            this.dtp_to.TabIndex = 28;
            // 
            // dtp_from
            // 
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(69, 12);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(98, 20);
            this.dtp_from.TabIndex = 27;
            // 
            // RPTAPDestributionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 166);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_to);
            this.Controls.Add(this.dtp_from);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RPTAPDestributionFrm";
            this.Text = "AP Destribution";
            this.Load += new System.EventHandler(this.RPTAPDestributionFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
    }
}