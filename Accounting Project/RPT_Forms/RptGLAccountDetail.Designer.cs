namespace Accounting_GeneralLedger
{
    partial class RptGLAccountDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptGLAccountDetail));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ListSelect = new System.Windows.Forms.ListBox();
            this.ListAvailable = new System.Windows.Forms.ListBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_AccountNumber1 = new System.Windows.Forms.MaskedTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txt_DepartmentCode = new System.Windows.Forms.TextBox();
            this.radio_account = new System.Windows.Forms.RadioButton();
            this.radio_department = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox3.Location = new System.Drawing.Point(177, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 258);
            this.groupBox3.TabIndex = 34;
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
            this.label4.Size = new System.Drawing.Size(37, 13);
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
            this.ListSelect.Size = new System.Drawing.Size(144, 212);
            this.ListSelect.Sorted = true;
            this.ListSelect.TabIndex = 1;
            this.ListSelect.DoubleClick += new System.EventHandler(this.ListSelect_DoubleClick);
            // 
            // ListAvailable
            // 
            this.ListAvailable.FormattingEnabled = true;
            this.ListAvailable.Location = new System.Drawing.Point(13, 30);
            this.ListAvailable.Name = "ListAvailable";
            this.ListAvailable.Size = new System.Drawing.Size(133, 212);
            this.ListAvailable.Sorted = true;
            this.ListAvailable.TabIndex = 0;
            this.ListAvailable.DoubleClick += new System.EventHandler(this.ListAvailable_DoubleClick);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(386, 383);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 33;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_to);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_from);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 124);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Range";
            // 
            // dtp_to
            // 
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to.Location = new System.Drawing.Point(48, 68);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(95, 20);
            this.dtp_to.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "From";
            // 
            // dtp_from
            // 
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(48, 29);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(95, 20);
            this.dtp_from.TabIndex = 32;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radio_department);
            this.groupBox2.Controls.Add(this.radio_account);
            this.groupBox2.Controls.Add(this.txt_DepartmentCode);
            this.groupBox2.Controls.Add(this.txt_AccountNumber1);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 128);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Account Range";
            // 
            // txt_AccountNumber1
            // 
            this.txt_AccountNumber1.Location = new System.Drawing.Point(48, 53);
            this.txt_AccountNumber1.Name = "txt_AccountNumber1";
            this.txt_AccountNumber1.PromptChar = '%';
            this.txt_AccountNumber1.Size = new System.Drawing.Size(94, 20);
            this.txt_AccountNumber1.TabIndex = 24;
            this.txt_AccountNumber1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txt_AccountNumber1_MaskInputRejected);
            this.txt_AccountNumber1.TextChanged += new System.EventHandler(this.txt_AccountNumber1_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgv);
            this.groupBox4.Location = new System.Drawing.Point(12, 276);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 197);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "G/L Account Selection";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(13, 19);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 20;
            this.dgv.Size = new System.Drawing.Size(349, 169);
            this.dgv.TabIndex = 38;
            this.dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_CellBeginEdit);
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            // 
            // txt_DepartmentCode
            // 
            this.txt_DepartmentCode.Location = new System.Drawing.Point(48, 102);
            this.txt_DepartmentCode.Name = "txt_DepartmentCode";
            this.txt_DepartmentCode.Size = new System.Drawing.Size(94, 20);
            this.txt_DepartmentCode.TabIndex = 25;
            this.txt_DepartmentCode.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // radio_account
            // 
            this.radio_account.AutoSize = true;
            this.radio_account.Location = new System.Drawing.Point(9, 30);
            this.radio_account.Name = "radio_account";
            this.radio_account.Size = new System.Drawing.Size(105, 17);
            this.radio_account.TabIndex = 26;
            this.radio_account.TabStop = true;
            this.radio_account.Text = "Account Number";
            this.radio_account.UseVisualStyleBackColor = true;
            // 
            // radio_department
            // 
            this.radio_department.AutoSize = true;
            this.radio_department.Location = new System.Drawing.Point(7, 84);
            this.radio_department.Name = "radio_department";
            this.radio_department.Size = new System.Drawing.Size(108, 17);
            this.radio_department.TabIndex = 27;
            this.radio_department.TabStop = true;
            this.radio_department.Text = "Department Code";
            this.radio_department.UseVisualStyleBackColor = true;
            // 
            // RptGLAccountDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 473);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnReport);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RptGLAccountDetail";
            this.Text = "G/L Detail Account";
            this.Load += new System.EventHandler(this.RptGLAccountDetail_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox ListSelect;
        private System.Windows.Forms.ListBox ListAvailable;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox txt_AccountNumber1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.RadioButton radio_department;
        private System.Windows.Forms.RadioButton radio_account;
        private System.Windows.Forms.TextBox txt_DepartmentCode;
    }
}