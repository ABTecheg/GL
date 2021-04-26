namespace Accounting_GeneralLedger
{
    partial class CurrencyConversionTable
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.btn_NewCode = new System.Windows.Forms.Button();
            this.txt_CurrencyCodeID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cb_currencycode1 = new System.Windows.Forms.ComboBox();
            this.txt_ExchangeRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lock41 = new System.Windows.Forms.GroupBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.Lock42 = new System.Windows.Forms.GroupBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.Lock43 = new System.Windows.Forms.GroupBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.GB1.SuspendLayout();
            this.Lock41.SuspendLayout();
            this.Lock42.SuspendLayout();
            this.Lock43.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(572, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(23, 36);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(529, 160);
            this.dgv.TabIndex = 11;
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.btn_NewCode);
            this.GB1.Controls.Add(this.txt_CurrencyCodeID);
            this.GB1.Controls.Add(this.label2);
            this.GB1.Controls.Add(this.dateTimePicker1);
            this.GB1.Controls.Add(this.cb_currencycode1);
            this.GB1.Controls.Add(this.txt_ExchangeRate);
            this.GB1.Controls.Add(this.label5);
            this.GB1.Controls.Add(this.label3);
            this.GB1.Controls.Add(this.label1);
            this.GB1.Enabled = false;
            this.GB1.Location = new System.Drawing.Point(89, 202);
            this.GB1.Name = "GB1";
            this.GB1.Size = new System.Drawing.Size(394, 140);
            this.GB1.TabIndex = 32;
            this.GB1.TabStop = false;
            this.GB1.EnabledChanged += new System.EventHandler(this.GB1_EnabledChanged);
            // 
            // btn_NewCode
            // 
            this.btn_NewCode.Location = new System.Drawing.Point(309, 12);
            this.btn_NewCode.Name = "btn_NewCode";
            this.btn_NewCode.Size = new System.Drawing.Size(63, 23);
            this.btn_NewCode.TabIndex = 24;
            this.btn_NewCode.Text = "New";
            this.btn_NewCode.UseVisualStyleBackColor = true;
            this.btn_NewCode.Visible = false;
            // 
            // txt_CurrencyCodeID
            // 
            this.txt_CurrencyCodeID.Location = new System.Drawing.Point(194, 14);
            this.txt_CurrencyCodeID.Name = "txt_CurrencyCodeID";
            this.txt_CurrencyCodeID.ReadOnly = true;
            this.txt_CurrencyCodeID.Size = new System.Drawing.Size(109, 20);
            this.txt_CurrencyCodeID.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Currency Code ID";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(194, 116);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(178, 20);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // cb_currencycode1
            // 
            this.cb_currencycode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_currencycode1.FormattingEnabled = true;
            this.cb_currencycode1.Location = new System.Drawing.Point(194, 46);
            this.cb_currencycode1.Name = "cb_currencycode1";
            this.cb_currencycode1.Size = new System.Drawing.Size(178, 21);
            this.cb_currencycode1.TabIndex = 20;
            this.cb_currencycode1.SelectedIndexChanged += new System.EventHandler(this.cb_currencycode1_SelectedIndexChanged);
            // 
            // txt_ExchangeRate
            // 
            this.txt_ExchangeRate.AcceptsReturn = true;
            this.txt_ExchangeRate.Location = new System.Drawing.Point(194, 78);
            this.txt_ExchangeRate.Name = "txt_ExchangeRate";
            this.txt_ExchangeRate.Size = new System.Drawing.Size(178, 20);
            this.txt_ExchangeRate.TabIndex = 19;
            this.txt_ExchangeRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ExchangeRate_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Effective Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Exchange Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Currency Code";
            // 
            // Lock41
            // 
            this.Lock41.Controls.Add(this.btn_New);
            this.Lock41.Controls.Add(this.btnSavenew);
            this.Lock41.Location = new System.Drawing.Point(65, 348);
            this.Lock41.Name = "Lock41";
            this.Lock41.Size = new System.Drawing.Size(69, 37);
            this.Lock41.TabIndex = 33;
            this.Lock41.TabStop = false;
            this.Lock41.Tag = "41";
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(0, 6);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(69, 31);
            this.btn_New.TabIndex = 54;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btnSavenew
            // 
            this.btnSavenew.Location = new System.Drawing.Point(0, 6);
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.Size = new System.Drawing.Size(69, 31);
            this.btnSavenew.TabIndex = 53;
            this.btnSavenew.Text = "Save";
            this.btnSavenew.UseVisualStyleBackColor = true;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // Lock42
            // 
            this.Lock42.Controls.Add(this.btnedit);
            this.Lock42.Controls.Add(this.Btnsaveedit);
            this.Lock42.Location = new System.Drawing.Point(162, 348);
            this.Lock42.Name = "Lock42";
            this.Lock42.Size = new System.Drawing.Size(69, 37);
            this.Lock42.TabIndex = 34;
            this.Lock42.TabStop = false;
            this.Lock42.Tag = "42";
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Location = new System.Drawing.Point(0, 6);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(69, 31);
            this.btnedit.TabIndex = 54;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // Btnsaveedit
            // 
            this.Btnsaveedit.Location = new System.Drawing.Point(0, 6);
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.Size = new System.Drawing.Size(69, 31);
            this.Btnsaveedit.TabIndex = 51;
            this.Btnsaveedit.Text = "Save";
            this.Btnsaveedit.UseVisualStyleBackColor = true;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // Lock43
            // 
            this.Lock43.Controls.Add(this.btndelete);
            this.Lock43.Location = new System.Drawing.Point(259, 348);
            this.Lock43.Name = "Lock43";
            this.Lock43.Size = new System.Drawing.Size(69, 37);
            this.Lock43.TabIndex = 35;
            this.Lock43.TabStop = false;
            this.Lock43.Tag = "43";
            // 
            // btndelete
            // 
            this.btndelete.Enabled = false;
            this.btndelete.Location = new System.Drawing.Point(0, 6);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(69, 31);
            this.btndelete.TabIndex = 52;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(453, 354);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(69, 31);
            this.btnexit.TabIndex = 61;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnundo
            // 
            this.btnundo.Location = new System.Drawing.Point(356, 354);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(69, 31);
            this.btnundo.TabIndex = 60;
            this.btnundo.Text = "Undo";
            this.btnundo.UseVisualStyleBackColor = true;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
            // 
            // CurrencyConversionTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(572, 395);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.Lock43);
            this.Controls.Add(this.Lock42);
            this.Controls.Add(this.Lock41);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.GB1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CurrencyConversionTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CurrencyConversionTable";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CurrencyConversionTable_FormClosing);
            this.Load += new System.EventHandler(this.CurrencyConversionTable_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.GB1.ResumeLayout(false);
            this.GB1.PerformLayout();
            this.Lock41.ResumeLayout(false);
            this.Lock42.ResumeLayout(false);
            this.Lock43.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox GB1;
        private System.Windows.Forms.Button btn_NewCode;
        private System.Windows.Forms.TextBox txt_CurrencyCodeID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cb_currencycode1;
        private System.Windows.Forms.TextBox txt_ExchangeRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Lock41;
        private System.Windows.Forms.GroupBox Lock42;
        private System.Windows.Forms.GroupBox Lock43;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btn_New;

    }
}