namespace Accounting_GeneralLedger
{
    partial class GeneralLedgerTemplate
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TemplateCode = new System.Windows.Forms.TextBox();
            this.txt_TemplateName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_JournalCode = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_SaveChanges = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_TemplateID = new System.Windows.Forms.TextBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Balance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Units = new System.Windows.Forms.TextBox();
            this.label_Currency = new System.Windows.Forms.Label();
            this.cb_Currency = new System.Windows.Forms.ComboBox();
            this.checkBox_Currency = new System.Windows.Forms.CheckBox();
            this.label_CurrencyRate = new System.Windows.Forms.Label();
            this.txt_CurrencyRate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(26, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template Code";
            // 
            // txt_TemplateCode
            // 
            this.txt_TemplateCode.Location = new System.Drawing.Point(241, 87);
            this.txt_TemplateCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_TemplateCode.MaxLength = 4;
            this.txt_TemplateCode.Name = "txt_TemplateCode";
            this.txt_TemplateCode.Size = new System.Drawing.Size(268, 22);
            this.txt_TemplateCode.TabIndex = 1;
            // 
            // txt_TemplateName
            // 
            this.txt_TemplateName.Location = new System.Drawing.Point(241, 117);
            this.txt_TemplateName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_TemplateName.MaxLength = 30;
            this.txt_TemplateName.Name = "txt_TemplateName";
            this.txt_TemplateName.Size = new System.Drawing.Size(268, 22);
            this.txt_TemplateName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(26, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Template Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(29, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Journal Voucher Code";
            // 
            // cb_JournalCode
            // 
            this.cb_JournalCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_JournalCode.FormattingEnabled = true;
            this.cb_JournalCode.Location = new System.Drawing.Point(241, 146);
            this.cb_JournalCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_JournalCode.Name = "cb_JournalCode";
            this.cb_JournalCode.Size = new System.Drawing.Size(268, 24);
            this.cb_JournalCode.TabIndex = 5;
            this.cb_JournalCode.SelectedIndexChanged += new System.EventHandler(this.cb_JournalCode_SelectedIndexChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(30, 258);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(781, 247);
            this.dgv.TabIndex = 6;
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            this.dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RowEnter);
            this.dgv.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_RowHeaderMouseClick);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_KeyDown);
            this.dgv.MouseLeave += new System.EventHandler(this.dgv_MouseLeave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.toolStripSeparator1,
            this.insertToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.insertToolStripMenuItem.Text = "Insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btn_SaveChanges
            // 
            this.btn_SaveChanges.Location = new System.Drawing.Point(659, 513);
            this.btn_SaveChanges.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SaveChanges.Name = "btn_SaveChanges";
            this.btn_SaveChanges.Size = new System.Drawing.Size(152, 38);
            this.btn_SaveChanges.TabIndex = 8;
            this.btn_SaveChanges.Text = "Save Changes";
            this.btn_SaveChanges.UseVisualStyleBackColor = true;
            this.btn_SaveChanges.Click += new System.EventHandler(this.btn_SaveChanges_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(26, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Template ID";
            // 
            // txt_TemplateID
            // 
            this.txt_TemplateID.Location = new System.Drawing.Point(241, 55);
            this.txt_TemplateID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_TemplateID.Name = "txt_TemplateID";
            this.txt_TemplateID.ReadOnly = true;
            this.txt_TemplateID.Size = new System.Drawing.Size(195, 22);
            this.txt_TemplateID.TabIndex = 10;
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(445, 55);
            this.btn_New.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(65, 25);
            this.btn_New.TabIndex = 11;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(29, 183);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "Balance";
            // 
            // txt_Balance
            // 
            this.txt_Balance.Location = new System.Drawing.Point(241, 180);
            this.txt_Balance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Balance.Name = "txt_Balance";
            this.txt_Balance.ReadOnly = true;
            this.txt_Balance.Size = new System.Drawing.Size(268, 22);
            this.txt_Balance.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightGray;
            this.label6.Location = new System.Drawing.Point(29, 215);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 21);
            this.label6.TabIndex = 14;
            this.label6.Text = "Units";
            // 
            // txt_Units
            // 
            this.txt_Units.Location = new System.Drawing.Point(241, 212);
            this.txt_Units.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Units.Name = "txt_Units";
            this.txt_Units.ReadOnly = true;
            this.txt_Units.Size = new System.Drawing.Size(268, 22);
            this.txt_Units.TabIndex = 15;
            // 
            // label_Currency
            // 
            this.label_Currency.AutoSize = true;
            this.label_Currency.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Currency.ForeColor = System.Drawing.Color.LightGray;
            this.label_Currency.Location = new System.Drawing.Point(525, 150);
            this.label_Currency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Currency.Name = "label_Currency";
            this.label_Currency.Size = new System.Drawing.Size(84, 21);
            this.label_Currency.TabIndex = 16;
            this.label_Currency.Text = "Currency";
            this.label_Currency.Visible = false;
            // 
            // cb_Currency
            // 
            this.cb_Currency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Currency.FormattingEnabled = true;
            this.cb_Currency.Location = new System.Drawing.Point(632, 146);
            this.cb_Currency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_Currency.Name = "cb_Currency";
            this.cb_Currency.Size = new System.Drawing.Size(177, 24);
            this.cb_Currency.TabIndex = 17;
            this.cb_Currency.Visible = false;
            this.cb_Currency.SelectedIndexChanged += new System.EventHandler(this.cb_Currency_SelectedIndexChanged);
            // 
            // checkBox_Currency
            // 
            this.checkBox_Currency.AutoSize = true;
            this.checkBox_Currency.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Currency.ForeColor = System.Drawing.Color.LightGray;
            this.checkBox_Currency.Location = new System.Drawing.Point(583, 91);
            this.checkBox_Currency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_Currency.Name = "checkBox_Currency";
            this.checkBox_Currency.Size = new System.Drawing.Size(146, 25);
            this.checkBox_Currency.TabIndex = 18;
            this.checkBox_Currency.Text = "MultiCurrency";
            this.checkBox_Currency.UseVisualStyleBackColor = true;
            this.checkBox_Currency.CheckedChanged += new System.EventHandler(this.checkBox_Currency_CheckedChanged);
            // 
            // label_CurrencyRate
            // 
            this.label_CurrencyRate.AutoSize = true;
            this.label_CurrencyRate.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurrencyRate.ForeColor = System.Drawing.Color.LightGray;
            this.label_CurrencyRate.Location = new System.Drawing.Point(525, 188);
            this.label_CurrencyRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_CurrencyRate.Name = "label_CurrencyRate";
            this.label_CurrencyRate.Size = new System.Drawing.Size(124, 21);
            this.label_CurrencyRate.TabIndex = 19;
            this.label_CurrencyRate.Text = "CurrencyRate";
            this.label_CurrencyRate.Visible = false;
            // 
            // txt_CurrencyRate
            // 
            this.txt_CurrencyRate.Location = new System.Drawing.Point(632, 183);
            this.txt_CurrencyRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_CurrencyRate.Name = "txt_CurrencyRate";
            this.txt_CurrencyRate.ReadOnly = true;
            this.txt_CurrencyRate.Size = new System.Drawing.Size(177, 22);
            this.txt_CurrencyRate.TabIndex = 20;
            this.txt_CurrencyRate.Visible = false;
            // 
            // GeneralLedgerTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(827, 559);
            this.Controls.Add(this.txt_CurrencyRate);
            this.Controls.Add(this.label_CurrencyRate);
            this.Controls.Add(this.checkBox_Currency);
            this.Controls.Add(this.cb_Currency);
            this.Controls.Add(this.label_Currency);
            this.Controls.Add(this.txt_Units);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Balance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.txt_TemplateID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_SaveChanges);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cb_JournalCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_TemplateName);
            this.Controls.Add(this.txt_TemplateCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GeneralLedgerTemplate";
            this.Text = "GeneralLedgerTemplate";
            this.Load += new System.EventHandler(this.GeneralLedgerTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TemplateCode;
        private System.Windows.Forms.TextBox txt_TemplateName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_JournalCode;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btn_SaveChanges;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.TextBox txt_TemplateID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Balance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Units;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_Currency;
        private System.Windows.Forms.Label label_Currency;
        private System.Windows.Forms.CheckBox checkBox_Currency;
        private System.Windows.Forms.TextBox txt_CurrencyRate;
        private System.Windows.Forms.Label label_CurrencyRate;
    }
}