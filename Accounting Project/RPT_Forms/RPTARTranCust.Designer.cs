namespace Accounting_GeneralLedger
{
    partial class RPTARTranCust
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPTARTranCust));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ListAvailable = new System.Windows.Forms.ListBox();
            this.ListSelect = new System.Windows.Forms.ListBox();
            this.rdAccountCode = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdAccountName = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Select";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Available";
            // 
            // ListAvailable
            // 
            this.ListAvailable.FormattingEnabled = true;
            this.ListAvailable.Location = new System.Drawing.Point(13, 30);
            this.ListAvailable.Name = "ListAvailable";
            this.ListAvailable.Size = new System.Drawing.Size(147, 173);
            this.ListAvailable.Sorted = true;
            this.ListAvailable.TabIndex = 0;
            this.ListAvailable.DoubleClick += new System.EventHandler(this.ListAvailable_DoubleClick);
            // 
            // ListSelect
            // 
            this.ListSelect.FormattingEnabled = true;
            this.ListSelect.Location = new System.Drawing.Point(208, 30);
            this.ListSelect.Name = "ListSelect";
            this.ListSelect.Size = new System.Drawing.Size(154, 173);
            this.ListSelect.Sorted = true;
            this.ListSelect.TabIndex = 1;
            this.ListSelect.DoubleClick += new System.EventHandler(this.ListSelect_DoubleClick);
            // 
            // rdAccountCode
            // 
            this.rdAccountCode.AutoSize = true;
            this.rdAccountCode.Location = new System.Drawing.Point(45, 19);
            this.rdAccountCode.Name = "rdAccountCode";
            this.rdAccountCode.Size = new System.Drawing.Size(95, 17);
            this.rdAccountCode.TabIndex = 3;
            this.rdAccountCode.TabStop = true;
            this.rdAccountCode.Text = "Account  Code";
            this.rdAccountCode.UseVisualStyleBackColor = true;
            this.rdAccountCode.CheckedChanged += new System.EventHandler(this.rdAccountCode_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdAccountCode);
            this.groupBox4.Controls.Add(this.rdAccountName);
            this.groupBox4.Location = new System.Drawing.Point(8, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 58);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select Options";
            // 
            // rdAccountName
            // 
            this.rdAccountName.AutoSize = true;
            this.rdAccountName.Location = new System.Drawing.Point(208, 19);
            this.rdAccountName.Name = "rdAccountName";
            this.rdAccountName.Size = new System.Drawing.Size(94, 17);
            this.rdAccountName.TabIndex = 2;
            this.rdAccountName.TabStop = true;
            this.rdAccountName.Text = "Account Name";
            this.rdAccountName.UseVisualStyleBackColor = true;
            this.rdAccountName.CheckedChanged += new System.EventHandler(this.rdAccountName_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ListSelect);
            this.groupBox1.Controls.Add(this.ListAvailable);
            this.groupBox1.Location = new System.Drawing.Point(8, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 218);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer";
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(166, 165);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 29);
            this.button4.TabIndex = 29;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(166, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 29);
            this.button3.TabIndex = 28;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(166, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 29);
            this.button2.TabIndex = 27;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(166, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 29);
            this.button1.TabIndex = 26;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtp_from
            // 
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(90, 6);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(98, 20);
            this.dtp_from.TabIndex = 42;
            // 
            // dtp_to
            // 
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to.Location = new System.Drawing.Point(237, 6);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(95, 20);
            this.dtp_to.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "To";
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(128, 322);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 47;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // RPTARTranCust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 377);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtp_from);
            this.Controls.Add(this.dtp_to);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RPTARTranCust";
            this.Text = "RPTARTranCust";
            this.Load += new System.EventHandler(this.RPTARTranCust_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListAvailable;
        private System.Windows.Forms.ListBox ListSelect;
        private System.Windows.Forms.RadioButton rdAccountCode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdAccountName;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}