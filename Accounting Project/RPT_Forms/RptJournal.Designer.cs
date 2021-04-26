namespace Accounting_GeneralLedger
{
    partial class RptJournal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptJournal));
            this.rdb_both = new System.Windows.Forms.RadioButton();
            this.rdb_unpost = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbsummer = new System.Windows.Forms.RadioButton();
            this.rdbdetails = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_post = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ListSelect = new System.Windows.Forms.ListBox();
            this.ListAvailable = new System.Windows.Forms.ListBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdb_both
            // 
            this.rdb_both.AutoSize = true;
            this.rdb_both.Location = new System.Drawing.Point(50, 64);
            this.rdb_both.Name = "rdb_both";
            this.rdb_both.Size = new System.Drawing.Size(47, 17);
            this.rdb_both.TabIndex = 2;
            this.rdb_both.TabStop = true;
            this.rdb_both.Text = "Both";
            this.rdb_both.UseVisualStyleBackColor = true;
            // 
            // rdb_unpost
            // 
            this.rdb_unpost.AutoSize = true;
            this.rdb_unpost.Location = new System.Drawing.Point(81, 30);
            this.rdb_unpost.Name = "rdb_unpost";
            this.rdb_unpost.Size = new System.Drawing.Size(71, 17);
            this.rdb_unpost.TabIndex = 1;
            this.rdb_unpost.TabStop = true;
            this.rdb_unpost.Text = "UnPosted";
            this.rdb_unpost.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbsummer);
            this.groupBox2.Controls.Add(this.rdbdetails);
            this.groupBox2.Location = new System.Drawing.Point(18, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 103);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Options";
            // 
            // rdbsummer
            // 
            this.rdbsummer.AutoSize = true;
            this.rdbsummer.Location = new System.Drawing.Point(6, 53);
            this.rdbsummer.Name = "rdbsummer";
            this.rdbsummer.Size = new System.Drawing.Size(114, 17);
            this.rdbsummer.TabIndex = 3;
            this.rdbsummer.TabStop = true;
            this.rdbsummer.Text = "Print Account Only";
            this.rdbsummer.UseVisualStyleBackColor = true;
            // 
            // rdbdetails
            // 
            this.rdbdetails.AutoSize = true;
            this.rdbdetails.Location = new System.Drawing.Point(6, 19);
            this.rdbdetails.Name = "rdbdetails";
            this.rdbdetails.Size = new System.Drawing.Size(137, 17);
            this.rdbdetails.TabIndex = 2;
            this.rdbdetails.TabStop = true;
            this.rdbdetails.Text = "Print With Batch Details";
            this.rdbdetails.UseVisualStyleBackColor = true;
            this.rdbdetails.CheckedChanged += new System.EventHandler(this.rdbdetails_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "From";
            // 
            // dtp_to
            // 
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to.Location = new System.Drawing.Point(307, 5);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(95, 20);
            this.dtp_to.TabIndex = 22;
            // 
            // dtp_from
            // 
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(160, 5);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(98, 20);
            this.dtp_from.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_both);
            this.groupBox1.Controls.Add(this.rdb_unpost);
            this.groupBox1.Controls.Add(this.rdb_post);
            this.groupBox1.Location = new System.Drawing.Point(16, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 111);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Status";
            // 
            // rdb_post
            // 
            this.rdb_post.AutoSize = true;
            this.rdb_post.Location = new System.Drawing.Point(8, 30);
            this.rdb_post.Name = "rdb_post";
            this.rdb_post.Size = new System.Drawing.Size(58, 17);
            this.rdb_post.TabIndex = 0;
            this.rdb_post.TabStop = true;
            this.rdb_post.Text = "Posted";
            this.rdb_post.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "To";
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(199, 266);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 26;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.ListSelect);
            this.groupBox3.Controls.Add(this.ListAvailable);
            this.groupBox3.Location = new System.Drawing.Point(199, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 218);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "G/L Journals";
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(152, 165);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 29);
            this.button4.TabIndex = 29;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(152, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 29);
            this.button3.TabIndex = 28;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(152, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 29);
            this.button2.TabIndex = 27;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(152, 45);
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
            this.ListSelect.Location = new System.Drawing.Point(194, 30);
            this.ListSelect.Name = "ListSelect";
            this.ListSelect.Size = new System.Drawing.Size(144, 173);
            this.ListSelect.Sorted = true;
            this.ListSelect.TabIndex = 1;
            this.ListSelect.DoubleClick += new System.EventHandler(this.ListSelect_DoubleClick);
            this.ListSelect.SelectedIndexChanged += new System.EventHandler(this.ListSelect_SelectedIndexChanged);
            // 
            // ListAvailable
            // 
            this.ListAvailable.FormattingEnabled = true;
            this.ListAvailable.Location = new System.Drawing.Point(13, 30);
            this.ListAvailable.Name = "ListAvailable";
            this.ListAvailable.Size = new System.Drawing.Size(133, 173);
            this.ListAvailable.Sorted = true;
            this.ListAvailable.TabIndex = 0;
            this.ListAvailable.DoubleClick += new System.EventHandler(this.ListAvailable_DoubleClick);
            this.ListAvailable.SelectedIndexChanged += new System.EventHandler(this.ListAvailable_SelectedIndexChanged);
            // 
            // RptJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 322);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_to);
            this.Controls.Add(this.dtp_from);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RptJournal";
            this.Text = "Journal Report";
            this.Load += new System.EventHandler(this.RptJournal_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_both;
        private System.Windows.Forms.RadioButton rdb_unpost;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_post;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbsummer;
        private System.Windows.Forms.RadioButton rdbdetails;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox ListSelect;
        private System.Windows.Forms.ListBox ListAvailable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}