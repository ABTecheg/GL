namespace Accounting_GeneralLedger
{
    partial class RPTVendorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPTVendorList));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdsortcategory = new System.Windows.Forms.RadioButton();
            this.rdsortname = new System.Windows.Forms.RadioButton();
            this.rdsortcode = new System.Windows.Forms.RadioButton();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ListSelect = new System.Windows.Forms.ListBox();
            this.ListAvailable = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbsummer = new System.Windows.Forms.RadioButton();
            this.rdbdetails = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdvendorcategory = new System.Windows.Forms.RadioButton();
            this.rdvendorcode = new System.Windows.Forms.RadioButton();
            this.rdvendorname = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdsortcategory);
            this.groupBox3.Controls.Add(this.rdsortname);
            this.groupBox3.Controls.Add(this.rdsortcode);
            this.groupBox3.Location = new System.Drawing.Point(12, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 100);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Display";
            // 
            // rdsortcategory
            // 
            this.rdsortcategory.AutoSize = true;
            this.rdsortcategory.Location = new System.Drawing.Point(19, 65);
            this.rdsortcategory.Name = "rdsortcategory";
            this.rdsortcategory.Size = new System.Drawing.Size(157, 17);
            this.rdsortcategory.TabIndex = 2;
            this.rdsortcategory.TabStop = true;
            this.rdsortcategory.Text = "Sorted By Vendor Category";
            this.rdsortcategory.UseVisualStyleBackColor = true;
            // 
            // rdsortname
            // 
            this.rdsortname.AutoSize = true;
            this.rdsortname.Location = new System.Drawing.Point(19, 42);
            this.rdsortname.Name = "rdsortname";
            this.rdsortname.Size = new System.Drawing.Size(139, 17);
            this.rdsortname.TabIndex = 1;
            this.rdsortname.TabStop = true;
            this.rdsortname.Text = "Sorted By Vendor Name";
            this.rdsortname.UseVisualStyleBackColor = true;
            // 
            // rdsortcode
            // 
            this.rdsortcode.AutoSize = true;
            this.rdsortcode.Location = new System.Drawing.Point(19, 19);
            this.rdsortcode.Name = "rdsortcode";
            this.rdsortcode.Size = new System.Drawing.Size(140, 17);
            this.rdsortcode.TabIndex = 0;
            this.rdsortcode.TabStop = true;
            this.rdsortcode.Text = "Sorted By Vendor Code ";
            this.rdsortcode.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(36, 227);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 24;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(225, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 218);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vendors";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbsummer);
            this.groupBox2.Controls.Add(this.rdbdetails);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 58);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Options";
            // 
            // rdbsummer
            // 
            this.rdbsummer.AutoSize = true;
            this.rdbsummer.Location = new System.Drawing.Point(19, 29);
            this.rdbsummer.Name = "rdbsummer";
            this.rdbsummer.Size = new System.Drawing.Size(69, 17);
            this.rdbsummer.TabIndex = 3;
            this.rdbsummer.TabStop = true;
            this.rdbsummer.Text = "Summary";
            this.rdbsummer.UseVisualStyleBackColor = true;
            // 
            // rdbdetails
            // 
            this.rdbdetails.AutoSize = true;
            this.rdbdetails.Location = new System.Drawing.Point(124, 29);
            this.rdbdetails.Name = "rdbdetails";
            this.rdbdetails.Size = new System.Drawing.Size(52, 17);
            this.rdbdetails.TabIndex = 2;
            this.rdbdetails.TabStop = true;
            this.rdbdetails.Text = "Detail";
            this.rdbdetails.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdvendorcategory);
            this.groupBox4.Controls.Add(this.rdvendorcode);
            this.groupBox4.Controls.Add(this.rdvendorname);
            this.groupBox4.Location = new System.Drawing.Point(225, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 58);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Select Options";
            // 
            // rdvendorcategory
            // 
            this.rdvendorcategory.AutoSize = true;
            this.rdvendorcategory.Location = new System.Drawing.Point(235, 29);
            this.rdvendorcategory.Name = "rdvendorcategory";
            this.rdvendorcategory.Size = new System.Drawing.Size(107, 17);
            this.rdvendorcategory.TabIndex = 4;
            this.rdvendorcategory.TabStop = true;
            this.rdvendorcategory.Text = "Vendor Category";
            this.rdvendorcategory.UseVisualStyleBackColor = true;
            this.rdvendorcategory.CheckedChanged += new System.EventHandler(this.rdvendorcategory_CheckedChanged);
            // 
            // rdvendorcode
            // 
            this.rdvendorcode.AutoSize = true;
            this.rdvendorcode.Location = new System.Drawing.Point(18, 29);
            this.rdvendorcode.Name = "rdvendorcode";
            this.rdvendorcode.Size = new System.Drawing.Size(87, 17);
            this.rdvendorcode.TabIndex = 3;
            this.rdvendorcode.TabStop = true;
            this.rdvendorcode.Text = "Vendor Code";
            this.rdvendorcode.UseVisualStyleBackColor = true;
            this.rdvendorcode.CheckedChanged += new System.EventHandler(this.rdvendorcode_CheckedChanged);
            // 
            // rdvendorname
            // 
            this.rdvendorname.AutoSize = true;
            this.rdvendorname.Location = new System.Drawing.Point(117, 29);
            this.rdvendorname.Name = "rdvendorname";
            this.rdvendorname.Size = new System.Drawing.Size(89, 17);
            this.rdvendorname.TabIndex = 2;
            this.rdvendorname.TabStop = true;
            this.rdvendorname.Text = "Vendor Name";
            this.rdvendorname.UseVisualStyleBackColor = true;
            this.rdvendorname.CheckedChanged += new System.EventHandler(this.rdvendorname_CheckedChanged);
            // 
            // RPTVendorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 313);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RPTVendorList";
            this.Text = "RPTVendorList";
            this.Load += new System.EventHandler(this.RPTVendorList_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdsortcategory;
        private System.Windows.Forms.RadioButton rdsortname;
        private System.Windows.Forms.RadioButton rdsortcode;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListSelect;
        private System.Windows.Forms.ListBox ListAvailable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbsummer;
        private System.Windows.Forms.RadioButton rdbdetails;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdvendorcategory;
        private System.Windows.Forms.RadioButton rdvendorcode;
        private System.Windows.Forms.RadioButton rdvendorname;
    }
}