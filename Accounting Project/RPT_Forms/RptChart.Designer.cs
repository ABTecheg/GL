namespace Accounting_GeneralLedger
{
    partial class RptChart
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
            this.rdbonly = new System.Windows.Forms.RadioButton();
            this.rdball = new System.Windows.Forms.RadioButton();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_AccountNumber1 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkrange = new System.Windows.Forms.CheckBox();
            this.dbAccountingProjectDS1 = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.dtpIN = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdnumber = new System.Windows.Forms.RadioButton();
            this.rdname = new System.Windows.Forms.RadioButton();
            this.rdType = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpIN);
            this.groupBox1.Controls.Add(this.rdbonly);
            this.groupBox1.Controls.Add(this.rdball);
            this.groupBox1.Location = new System.Drawing.Point(32, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Options";
            // 
            // rdbonly
            // 
            this.rdbonly.AutoSize = true;
            this.rdbonly.Location = new System.Drawing.Point(19, 42);
            this.rdbonly.Name = "rdbonly";
            this.rdbonly.Size = new System.Drawing.Size(130, 17);
            this.rdbonly.TabIndex = 2;
            this.rdbonly.TabStop = true;
            this.rdbonly.Text = "Active Accounts  Only";
            this.rdbonly.UseVisualStyleBackColor = true;
            // 
            // rdball
            // 
            this.rdball.AutoSize = true;
            this.rdball.Location = new System.Drawing.Point(19, 19);
            this.rdball.Name = "rdball";
            this.rdball.Size = new System.Drawing.Size(83, 17);
            this.rdball.TabIndex = 0;
            this.rdball.TabStop = true;
            this.rdball.Text = "All Accounts";
            this.rdball.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(46, 322);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_AccountNumber1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkrange);
            this.groupBox2.Location = new System.Drawing.Point(32, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 91);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Range";
            // 
            // txt_AccountNumber1
            // 
            this.txt_AccountNumber1.Location = new System.Drawing.Point(14, 59);
            this.txt_AccountNumber1.Name = "txt_AccountNumber1";
            this.txt_AccountNumber1.PromptChar = '%';
            this.txt_AccountNumber1.Size = new System.Drawing.Size(131, 20);
            this.txt_AccountNumber1.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Account Number";
            // 
            // chkrange
            // 
            this.chkrange.AutoSize = true;
            this.chkrange.Location = new System.Drawing.Point(10, 23);
            this.chkrange.Name = "chkrange";
            this.chkrange.Size = new System.Drawing.Size(139, 17);
            this.chkrange.TabIndex = 22;
            this.chkrange.Text = "Print By Account Range";
            this.chkrange.UseVisualStyleBackColor = true;
            // 
            // dbAccountingProjectDS1
            // 
            this.dbAccountingProjectDS1.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpIN
            // 
            this.dtpIN.CustomFormat = "yyyy";
            this.dtpIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIN.Location = new System.Drawing.Point(77, 65);
            this.dtpIN.Name = "dtpIN";
            this.dtpIN.Size = new System.Drawing.Size(52, 20);
            this.dtpIN.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "IN Year";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdType);
            this.groupBox3.Controls.Add(this.rdname);
            this.groupBox3.Controls.Add(this.rdnumber);
            this.groupBox3.Location = new System.Drawing.Point(32, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Display";
            // 
            // rdnumber
            // 
            this.rdnumber.AutoSize = true;
            this.rdnumber.Location = new System.Drawing.Point(19, 19);
            this.rdnumber.Name = "rdnumber";
            this.rdnumber.Size = new System.Drawing.Size(157, 17);
            this.rdnumber.TabIndex = 0;
            this.rdnumber.TabStop = true;
            this.rdnumber.Text = "Sorted By Account Number ";
            this.rdnumber.UseVisualStyleBackColor = true;
            // 
            // rdname
            // 
            this.rdname.AutoSize = true;
            this.rdname.Location = new System.Drawing.Point(19, 42);
            this.rdname.Name = "rdname";
            this.rdname.Size = new System.Drawing.Size(144, 17);
            this.rdname.TabIndex = 1;
            this.rdname.TabStop = true;
            this.rdname.Text = "Sorted By Account Name";
            this.rdname.UseVisualStyleBackColor = true;
            // 
            // rdType
            // 
            this.rdType.AutoSize = true;
            this.rdType.Location = new System.Drawing.Point(19, 65);
            this.rdType.Name = "rdType";
            this.rdType.Size = new System.Drawing.Size(141, 17);
            this.rdType.TabIndex = 2;
            this.rdType.TabStop = true;
            this.rdType.Text = "Sorted By Account Type";
            this.rdType.UseVisualStyleBackColor = true;
            // 
            // RptChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 378);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RptChart";
            this.Text = "Chart of Account Report";
            this.Load += new System.EventHandler(this.RptChart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbonly;
        private System.Windows.Forms.RadioButton rdball;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkrange;
        private System.Windows.Forms.MaskedTextBox txt_AccountNumber1;
        private System.Windows.Forms.Label label4;
        private dbAccountingProjectDS dbAccountingProjectDS1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpIN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdnumber;
        private System.Windows.Forms.RadioButton rdType;
        private System.Windows.Forms.RadioButton rdname;
    }
}