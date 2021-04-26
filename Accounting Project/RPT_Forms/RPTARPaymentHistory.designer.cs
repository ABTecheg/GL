namespace Accounting_GeneralLedger
{
    partial class RPTARPaymentHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPTARPaymentHistory));
            this.label4 = new System.Windows.Forms.Label();
            this.ListAvailable = new System.Windows.Forms.ListBox();
            this.ListSelect = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdsortcategory = new System.Windows.Forms.RadioButton();
            this.rdsortname = new System.Windows.Forms.RadioButton();
            this.rdsortcode = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdAccountcategory = new System.Windows.Forms.RadioButton();
            this.rdAccountcode = new System.Windows.Forms.RadioButton();
            this.rdAccountname = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Available";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdsortcategory);
            this.groupBox3.Controls.Add(this.rdsortname);
            this.groupBox3.Controls.Add(this.rdsortcode);
            this.groupBox3.Location = new System.Drawing.Point(12, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 111);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Display";
            // 
            // rdsortcategory
            // 
            this.rdsortcategory.AutoSize = true;
            this.rdsortcategory.Location = new System.Drawing.Point(19, 75);
            this.rdsortcategory.Name = "rdsortcategory";
            this.rdsortcategory.Size = new System.Drawing.Size(162, 17);
            this.rdsortcategory.TabIndex = 2;
            this.rdsortcategory.TabStop = true;
            this.rdsortcategory.Text = "Sorted By Account Category";
            this.rdsortcategory.UseVisualStyleBackColor = true;
            // 
            // rdsortname
            // 
            this.rdsortname.AutoSize = true;
            this.rdsortname.Location = new System.Drawing.Point(19, 52);
            this.rdsortname.Name = "rdsortname";
            this.rdsortname.Size = new System.Drawing.Size(144, 17);
            this.rdsortname.TabIndex = 1;
            this.rdsortname.TabStop = true;
            this.rdsortname.Text = "Sorted By Account Name";
            this.rdsortname.UseVisualStyleBackColor = true;
            // 
            // rdsortcode
            // 
            this.rdsortcode.AutoSize = true;
            this.rdsortcode.Location = new System.Drawing.Point(19, 29);
            this.rdsortcode.Name = "rdsortcode";
            this.rdsortcode.Size = new System.Drawing.Size(145, 17);
            this.rdsortcode.TabIndex = 0;
            this.rdsortcode.TabStop = true;
            this.rdsortcode.Text = "Sorted By Account Code ";
            this.rdsortcode.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdAccountcategory);
            this.groupBox4.Controls.Add(this.rdAccountcode);
            this.groupBox4.Controls.Add(this.rdAccountname);
            this.groupBox4.Location = new System.Drawing.Point(215, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 58);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select Options";
            // 
            // rdAccountcategory
            // 
            this.rdAccountcategory.AutoSize = true;
            this.rdAccountcategory.Location = new System.Drawing.Point(235, 29);
            this.rdAccountcategory.Name = "rdAccountcategory";
            this.rdAccountcategory.Size = new System.Drawing.Size(112, 17);
            this.rdAccountcategory.TabIndex = 4;
            this.rdAccountcategory.TabStop = true;
            this.rdAccountcategory.Text = "Account Category";
            this.rdAccountcategory.UseVisualStyleBackColor = true;
            this.rdAccountcategory.CheckedChanged += new System.EventHandler(this.rdAccountcategory_CheckedChanged);
            // 
            // rdAccountcode
            // 
            this.rdAccountcode.AutoSize = true;
            this.rdAccountcode.Location = new System.Drawing.Point(18, 29);
            this.rdAccountcode.Name = "rdAccountcode";
            this.rdAccountcode.Size = new System.Drawing.Size(95, 17);
            this.rdAccountcode.TabIndex = 3;
            this.rdAccountcode.TabStop = true;
            this.rdAccountcode.Text = "Account  Code";
            this.rdAccountcode.UseVisualStyleBackColor = true;
            this.rdAccountcode.CheckedChanged += new System.EventHandler(this.rdAccountcode_CheckedChanged);
            // 
            // rdAccountname
            // 
            this.rdAccountname.AutoSize = true;
            this.rdAccountname.Location = new System.Drawing.Point(117, 29);
            this.rdAccountname.Name = "rdAccountname";
            this.rdAccountname.Size = new System.Drawing.Size(94, 17);
            this.rdAccountname.TabIndex = 2;
            this.rdAccountname.TabStop = true;
            this.rdAccountname.Text = "Account Name";
            this.rdAccountname.UseVisualStyleBackColor = true;
            this.rdAccountname.CheckedChanged += new System.EventHandler(this.rdAccountname_CheckedChanged);
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
            this.groupBox1.Location = new System.Drawing.Point(215, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 218);
            this.groupBox1.TabIndex = 45;
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
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(37, 230);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 48;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtp_to);
            this.groupBox2.Controls.Add(this.dtp_from);
            this.groupBox2.Location = new System.Drawing.Point(12, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 88);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date  Range";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "From";
            // 
            // dtp_to
            // 
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to.Location = new System.Drawing.Point(57, 53);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(107, 20);
            this.dtp_to.TabIndex = 23;
            // 
            // dtp_from
            // 
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(57, 27);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(107, 20);
            this.dtp_from.TabIndex = 22;
            // 
            // RPTARPaymentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 301);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RPTARPaymentHistory";
            this.Text = "AR Payment History Report";
            this.Load += new System.EventHandler(this.RPTARPaymentHistory_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox ListAvailable;
        private System.Windows.Forms.ListBox ListSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdsortcategory;
        private System.Windows.Forms.RadioButton rdsortname;
        private System.Windows.Forms.RadioButton rdsortcode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdAccountcategory;
        private System.Windows.Forms.RadioButton rdAccountcode;
        private System.Windows.Forms.RadioButton rdAccountname;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
    }
}