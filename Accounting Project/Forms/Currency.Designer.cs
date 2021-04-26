namespace Accounting_GeneralLedger
{
    partial class Currency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Currency));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.txtCurrencySign = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_CurrencyCodeID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_CurrencyAccountBrowse = new System.Windows.Forms.Button();
            this.btn_GLAccountBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_CurrencyAccountNumber = new System.Windows.Forms.TextBox();
            this.txt_GLAccountNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_baseCurrency = new System.Windows.Forms.CheckBox();
            this.checkBox_Active = new System.Windows.Forms.CheckBox();
            this.txt_CurrencyDescription = new System.Windows.Forms.TextBox();
            this.txt_CurrencyCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Lock44 = new System.Windows.Forms.GroupBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.Lock45 = new System.Windows.Forms.GroupBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.Lock46 = new System.Windows.Forms.GroupBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.GB1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.Lock44.SuspendLayout();
            this.Lock45.SuspendLayout();
            this.Lock46.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            resources.ApplyResources(this.insertToolStripMenuItem, "insertToolStripMenuItem");
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.txtCurrencySign);
            this.GB1.Controls.Add(this.label6);
            this.GB1.Controls.Add(this.txt_CurrencyCodeID);
            this.GB1.Controls.Add(this.label5);
            this.GB1.Controls.Add(this.btn_CurrencyAccountBrowse);
            this.GB1.Controls.Add(this.btn_GLAccountBrowse);
            this.GB1.Controls.Add(this.label4);
            this.GB1.Controls.Add(this.txt_CurrencyAccountNumber);
            this.GB1.Controls.Add(this.txt_GLAccountNumber);
            this.GB1.Controls.Add(this.label1);
            this.GB1.Controls.Add(this.checkBox_baseCurrency);
            this.GB1.Controls.Add(this.checkBox_Active);
            this.GB1.Controls.Add(this.txt_CurrencyDescription);
            this.GB1.Controls.Add(this.txt_CurrencyCode);
            this.GB1.Controls.Add(this.label3);
            this.GB1.Controls.Add(this.label2);
            resources.ApplyResources(this.GB1, "GB1");
            this.GB1.Name = "GB1";
            this.GB1.TabStop = false;
            this.GB1.EnabledChanged += new System.EventHandler(this.GB1_EnabledChanged);
            // 
            // txtCurrencySign
            // 
            resources.ApplyResources(this.txtCurrencySign, "txtCurrencySign");
            this.txtCurrencySign.Name = "txtCurrencySign";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txt_CurrencyCodeID
            // 
            resources.ApplyResources(this.txt_CurrencyCodeID, "txt_CurrencyCodeID");
            this.txt_CurrencyCodeID.Name = "txt_CurrencyCodeID";
            this.txt_CurrencyCodeID.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btn_CurrencyAccountBrowse
            // 
            resources.ApplyResources(this.btn_CurrencyAccountBrowse, "btn_CurrencyAccountBrowse");
            this.btn_CurrencyAccountBrowse.Name = "btn_CurrencyAccountBrowse";
            this.btn_CurrencyAccountBrowse.UseVisualStyleBackColor = true;
            this.btn_CurrencyAccountBrowse.Click += new System.EventHandler(this.btn_CurrencyAccountBrowse_Click);
            // 
            // btn_GLAccountBrowse
            // 
            resources.ApplyResources(this.btn_GLAccountBrowse, "btn_GLAccountBrowse");
            this.btn_GLAccountBrowse.Name = "btn_GLAccountBrowse";
            this.btn_GLAccountBrowse.UseVisualStyleBackColor = true;
            this.btn_GLAccountBrowse.Click += new System.EventHandler(this.btn_GLAccountBrowse_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txt_CurrencyAccountNumber
            // 
            resources.ApplyResources(this.txt_CurrencyAccountNumber, "txt_CurrencyAccountNumber");
            this.txt_CurrencyAccountNumber.Name = "txt_CurrencyAccountNumber";
            // 
            // txt_GLAccountNumber
            // 
            resources.ApplyResources(this.txt_GLAccountNumber, "txt_GLAccountNumber");
            this.txt_GLAccountNumber.Name = "txt_GLAccountNumber";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // checkBox_baseCurrency
            // 
            resources.ApplyResources(this.checkBox_baseCurrency, "checkBox_baseCurrency");
            this.checkBox_baseCurrency.Name = "checkBox_baseCurrency";
            this.checkBox_baseCurrency.UseVisualStyleBackColor = true;
            // 
            // checkBox_Active
            // 
            resources.ApplyResources(this.checkBox_Active, "checkBox_Active");
            this.checkBox_Active.Name = "checkBox_Active";
            this.checkBox_Active.UseVisualStyleBackColor = true;
            // 
            // txt_CurrencyDescription
            // 
            resources.ApplyResources(this.txt_CurrencyDescription, "txt_CurrencyDescription");
            this.txt_CurrencyDescription.Name = "txt_CurrencyDescription";
            // 
            // txt_CurrencyCode
            // 
            resources.ApplyResources(this.txt_CurrencyCode, "txt_CurrencyCode");
            this.txt_CurrencyCode.Name = "txt_CurrencyCode";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnUndo
            // 
            resources.ApplyResources(this.btnUndo, "btnUndo");
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // Lock44
            // 
            this.Lock44.Controls.Add(this.btn_New);
            this.Lock44.Controls.Add(this.btnSavenew);
            resources.ApplyResources(this.Lock44, "Lock44");
            this.Lock44.Name = "Lock44";
            this.Lock44.TabStop = false;
            this.Lock44.Tag = "44";
            // 
            // btn_New
            // 
            resources.ApplyResources(this.btn_New, "btn_New");
            this.btn_New.Name = "btn_New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btnSavenew
            // 
            resources.ApplyResources(this.btnSavenew, "btnSavenew");
            this.btnSavenew.Name = "btnSavenew";
            this.btnSavenew.UseVisualStyleBackColor = true;
            this.btnSavenew.Click += new System.EventHandler(this.btnSavenew_Click);
            // 
            // Lock45
            // 
            this.Lock45.Controls.Add(this.btnedit);
            this.Lock45.Controls.Add(this.Btnsaveedit);
            resources.ApplyResources(this.Lock45, "Lock45");
            this.Lock45.Name = "Lock45";
            this.Lock45.TabStop = false;
            this.Lock45.Tag = "45";
            // 
            // btnedit
            // 
            resources.ApplyResources(this.btnedit, "btnedit");
            this.btnedit.Name = "btnedit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // Btnsaveedit
            // 
            resources.ApplyResources(this.Btnsaveedit, "Btnsaveedit");
            this.Btnsaveedit.Name = "Btnsaveedit";
            this.Btnsaveedit.UseVisualStyleBackColor = true;
            this.Btnsaveedit.Click += new System.EventHandler(this.Btnsaveedit_Click);
            // 
            // Lock46
            // 
            this.Lock46.Controls.Add(this.btndelete);
            resources.ApplyResources(this.Lock46, "Lock46");
            this.Lock46.Name = "Lock46";
            this.Lock46.TabStop = false;
            this.Lock46.Tag = "46";
            // 
            // btndelete
            // 
            resources.ApplyResources(this.btndelete, "btndelete");
            this.btndelete.Name = "btndelete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // Currency
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.Lock46);
            this.Controls.Add(this.Lock45);
            this.Controls.Add(this.Lock44);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.GB1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Currency";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Currency_FormClosing);
            this.Load += new System.EventHandler(this.Currency_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GB1.ResumeLayout(false);
            this.GB1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.Lock44.ResumeLayout(false);
            this.Lock45.ResumeLayout(false);
            this.Lock46.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        //private System.Windows.Forms.DataGridViewTextBoxColumn currencyNumberDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn currencyCodeDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn gLAccountNumberDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn currencyPLAccountNumberDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn currencyDescriptionDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn;
        //private System.Windows.Forms.DataGridViewCheckBoxColumn baseCurrencyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox GB1;
        private System.Windows.Forms.TextBox txt_CurrencyCodeID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_CurrencyAccountBrowse;
        private System.Windows.Forms.Button btn_GLAccountBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_CurrencyAccountNumber;
        private System.Windows.Forms.TextBox txt_GLAccountNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_baseCurrency;
        private System.Windows.Forms.CheckBox checkBox_Active;
        private System.Windows.Forms.TextBox txt_CurrencyDescription;
        private System.Windows.Forms.TextBox txt_CurrencyCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrencySign;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox Lock44;
        private System.Windows.Forms.GroupBox Lock45;
        private System.Windows.Forms.GroupBox Lock46;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
    }
}