namespace Accounting_GeneralLedger {
    partial class BudgetMaintenance {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BudgetMaintenance));
            this.btn_SelectCurrentRecord = new System.Windows.Forms.Button();
            this.checkBox_Active = new System.Windows.Forms.CheckBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cbFiscalYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.Lock66 = new System.Windows.Forms.GroupBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.Lock18 = new System.Windows.Forms.GroupBox();
            this.txt_AccountNumber1 = new System.Windows.Forms.MaskedTextBox();
            this.dbAccountingProjectDSBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.dbAccountingProjectDSBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.Lock66.SuspendLayout();
            this.Lock18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_SelectCurrentRecord
            // 
            this.btn_SelectCurrentRecord.Location = new System.Drawing.Point(326, 478);
            this.btn_SelectCurrentRecord.Name = "btn_SelectCurrentRecord";
            this.btn_SelectCurrentRecord.Size = new System.Drawing.Size(150, 24);
            this.btn_SelectCurrentRecord.TabIndex = 20;
            this.btn_SelectCurrentRecord.Text = "Select Current Records";
            this.btn_SelectCurrentRecord.UseVisualStyleBackColor = true;
            this.btn_SelectCurrentRecord.Visible = false;
            this.btn_SelectCurrentRecord.Click += new System.EventHandler(this.btn_SelectCurrentRecord_Click);
            // 
            // checkBox_Active
            // 
            this.checkBox_Active.AutoSize = true;
            this.checkBox_Active.Location = new System.Drawing.Point(257, 81);
            this.checkBox_Active.Name = "checkBox_Active";
            this.checkBox_Active.Size = new System.Drawing.Size(150, 17);
            this.checkBox_Active.TabIndex = 19;
            this.checkBox_Active.Text = "Include Inactive Accounts";
            this.checkBox_Active.UseVisualStyleBackColor = true;
            this.checkBox_Active.CheckedChanged += new System.EventHandler(this.checkBox_Active_CheckedChanged);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(0, 6);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(120, 24);
            this.btn_Add.TabIndex = 18;
            this.btn_Add.Text = "Add New Account";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Account Number";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Enabled = false;
            this.dgv.Location = new System.Drawing.Point(3, 104);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 25;
            this.dgv.Size = new System.Drawing.Size(621, 280);
            this.dgv.TabIndex = 17;
            this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            // 
            // cbFiscalYear
            // 
            this.cbFiscalYear.FormattingEnabled = true;
            this.cbFiscalYear.Location = new System.Drawing.Point(257, 48);
            this.cbFiscalYear.Name = "cbFiscalYear";
            this.cbFiscalYear.Size = new System.Drawing.Size(87, 21);
            this.cbFiscalYear.TabIndex = 21;
            this.cbFiscalYear.SelectedIndexChanged += new System.EventHandler(this.cbFiscalYear_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Fiscal Year";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(0, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(540, 398);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Lock66
            // 
            this.Lock66.Controls.Add(this.btnedit);
            this.Lock66.Controls.Add(this.btnSave);
            this.Lock66.Location = new System.Drawing.Point(281, 392);
            this.Lock66.Name = "Lock66";
            this.Lock66.Size = new System.Drawing.Size(75, 29);
            this.Lock66.TabIndex = 48;
            this.Lock66.TabStop = false;
            this.Lock66.Tag = "66";
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(0, 6);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(75, 23);
            this.btnedit.TabIndex = 28;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // Lock18
            // 
            this.Lock18.Controls.Add(this.btn_Add);
            this.Lock18.Location = new System.Drawing.Point(388, 391);
            this.Lock18.Name = "Lock18";
            this.Lock18.Size = new System.Drawing.Size(120, 30);
            this.Lock18.TabIndex = 49;
            this.Lock18.TabStop = false;
            this.Lock18.Tag = "18";
            // 
            // txt_AccountNumber1
            // 
            this.txt_AccountNumber1.Location = new System.Drawing.Point(257, 22);
            this.txt_AccountNumber1.Name = "txt_AccountNumber1";
            this.txt_AccountNumber1.PromptChar = '%';
            this.txt_AccountNumber1.Size = new System.Drawing.Size(131, 20);
            this.txt_AccountNumber1.TabIndex = 19;
            this.txt_AccountNumber1.DoubleClick += new System.EventHandler(this.txt_AccountNumber1_DoubleClick);
            this.txt_AccountNumber1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_AccountNumber1_KeyPress);
            // 
            // dbAccountingProjectDSBindingSource2
            // 
            this.dbAccountingProjectDSBindingSource2.DataSource = this.dbAccountingProjectDS;
            this.dbAccountingProjectDSBindingSource2.Position = 0;
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dbAccountingProjectDSBindingSource1
            // 
            this.dbAccountingProjectDSBindingSource1.DataSource = this.dbAccountingProjectDS;
            this.dbAccountingProjectDSBindingSource1.Position = 0;
            // 
            // dbAccountingProjectDSBindingSource
            // 
            this.dbAccountingProjectDSBindingSource.DataSource = this.dbAccountingProjectDS;
            this.dbAccountingProjectDSBindingSource.Position = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 31);
            this.button1.TabIndex = 50;
            this.button1.Text = "Export to Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 47);
            this.button2.TabIndex = 51;
            this.button2.Text = "Create Budget";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(511, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 86);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // BudgetMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(627, 435);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_AccountNumber1);
            this.Controls.Add(this.Lock18);
            this.Controls.Add(this.Lock66);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFiscalYear);
            this.Controls.Add(this.btn_SelectCurrentRecord);
            this.Controls.Add(this.checkBox_Active);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BudgetMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BudgetMaintenance";
            this.Load += new System.EventHandler(this.BudgetMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.Lock66.ResumeLayout(false);
            this.Lock18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource2;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource1;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private System.Windows.Forms.Button btn_SelectCurrentRecord;
        private System.Windows.Forms.CheckBox checkBox_Active;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cbFiscalYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox Lock66;
        private System.Windows.Forms.GroupBox Lock18;
        private System.Windows.Forms.MaskedTextBox txt_AccountNumber1;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}