namespace Accounting_GeneralLedger
{
    partial class ApplyCreditsScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplyCreditsScreen));
            this.rd_Batch = new System.Windows.Forms.RadioButton();
            this.rd_Credits = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd_VendorCode = new System.Windows.Forms.RadioButton();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label_Mode = new System.Windows.Forms.Label();
            this.txt_Mode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Balance = new System.Windows.Forms.TextBox();
            this.btn_Distribute = new System.Windows.Forms.Button();
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Currency = new System.Windows.Forms.ComboBox();
            this.dgv_CreditTransaction = new System.Windows.Forms.DataGridView();
            this.dgv_AccountCharges = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CreditTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AccountCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // rd_Batch
            // 
            this.rd_Batch.AutoSize = true;
            this.rd_Batch.Location = new System.Drawing.Point(6, 63);
            this.rd_Batch.Name = "rd_Batch";
            this.rd_Batch.Size = new System.Drawing.Size(68, 17);
            this.rd_Batch.TabIndex = 1;
            this.rd_Batch.TabStop = true;
            this.rd_Batch.Text = "By Batch";
            this.rd_Batch.UseVisualStyleBackColor = true;
            this.rd_Batch.CheckedChanged += new System.EventHandler(this.rd_Batch_CheckedChanged);
            // 
            // rd_Credits
            // 
            this.rd_Credits.AutoSize = true;
            this.rd_Credits.Location = new System.Drawing.Point(6, 19);
            this.rd_Credits.Name = "rd_Credits";
            this.rd_Credits.Size = new System.Drawing.Size(71, 17);
            this.rd_Credits.TabIndex = 2;
            this.rd_Credits.TabStop = true;
            this.rd_Credits.Text = "All Credits";
            this.rd_Credits.UseVisualStyleBackColor = true;
            this.rd_Credits.CheckedChanged += new System.EventHandler(this.rd_Credits_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_VendorCode);
            this.groupBox1.Controls.Add(this.rd_Credits);
            this.groupBox1.Controls.Add(this.rd_Batch);
            this.groupBox1.Location = new System.Drawing.Point(395, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 85);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Apply Mode";
            // 
            // rd_VendorCode
            // 
            this.rd_VendorCode.AutoSize = true;
            this.rd_VendorCode.Location = new System.Drawing.Point(6, 41);
            this.rd_VendorCode.Name = "rd_VendorCode";
            this.rd_VendorCode.Size = new System.Drawing.Size(102, 17);
            this.rd_VendorCode.TabIndex = 3;
            this.rd_VendorCode.TabStop = true;
            this.rd_VendorCode.Text = "By Vendor Code";
            this.rd_VendorCode.UseVisualStyleBackColor = true;
            this.rd_VendorCode.CheckedChanged += new System.EventHandler(this.rd_VendorCode_CheckedChanged);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(296, 12);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(93, 21);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.Text = "Search";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label_Mode
            // 
            this.label_Mode.AutoSize = true;
            this.label_Mode.Location = new System.Drawing.Point(32, 15);
            this.label_Mode.Name = "label_Mode";
            this.label_Mode.Size = new System.Drawing.Size(69, 13);
            this.label_Mode.TabIndex = 6;
            this.label_Mode.Text = "Vendor Code";
            // 
            // txt_Mode
            // 
            this.txt_Mode.Location = new System.Drawing.Point(147, 13);
            this.txt_Mode.Name = "txt_Mode";
            this.txt_Mode.Size = new System.Drawing.Size(143, 20);
            this.txt_Mode.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Balance To Distribute";
            // 
            // txt_Balance
            // 
            this.txt_Balance.Location = new System.Drawing.Point(147, 68);
            this.txt_Balance.Name = "txt_Balance";
            this.txt_Balance.ReadOnly = true;
            this.txt_Balance.Size = new System.Drawing.Size(143, 20);
            this.txt_Balance.TabIndex = 9;
            // 
            // btn_Distribute
            // 
            this.btn_Distribute.Location = new System.Drawing.Point(299, 67);
            this.btn_Distribute.Name = "btn_Distribute";
            this.btn_Distribute.Size = new System.Drawing.Size(90, 21);
            this.btn_Distribute.TabIndex = 10;
            this.btn_Distribute.Text = "Distribute";
            this.btn_Distribute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Distribute.UseVisualStyleBackColor = true;
            this.btn_Distribute.Click += new System.EventHandler(this.btn_Distribute_Click);
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(549, 18);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(114, 62);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "Save ";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Currency Code";
            this.label1.Visible = false;
            // 
            // cb_Currency
            // 
            this.cb_Currency.FormattingEnabled = true;
            this.cb_Currency.Location = new System.Drawing.Point(147, 40);
            this.cb_Currency.Name = "cb_Currency";
            this.cb_Currency.Size = new System.Drawing.Size(242, 21);
            this.cb_Currency.TabIndex = 15;
            this.cb_Currency.Visible = false;
            this.cb_Currency.SelectedIndexChanged += new System.EventHandler(this.cb_Currency_SelectedIndexChanged);
            // 
            // dgv_CreditTransaction
            // 
            this.dgv_CreditTransaction.AllowUserToAddRows = false;
            this.dgv_CreditTransaction.AllowUserToDeleteRows = false;
            this.dgv_CreditTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_CreditTransaction.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_CreditTransaction.Location = new System.Drawing.Point(6, 103);
            this.dgv_CreditTransaction.Name = "dgv_CreditTransaction";
            this.dgv_CreditTransaction.RowHeadersWidth = 25;
            this.dgv_CreditTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CreditTransaction.Size = new System.Drawing.Size(802, 153);
            this.dgv_CreditTransaction.TabIndex = 16;
            this.dgv_CreditTransaction.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_CreditTransaction_MouseClick);
            // 
            // dgv_AccountCharges
            // 
            this.dgv_AccountCharges.AllowUserToAddRows = false;
            this.dgv_AccountCharges.AllowUserToDeleteRows = false;
            this.dgv_AccountCharges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_AccountCharges.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_AccountCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AccountCharges.Location = new System.Drawing.Point(6, 262);
            this.dgv_AccountCharges.MultiSelect = false;
            this.dgv_AccountCharges.Name = "dgv_AccountCharges";
            this.dgv_AccountCharges.RowHeadersVisible = false;
            this.dgv_AccountCharges.Size = new System.Drawing.Size(802, 199);
            this.dgv_AccountCharges.TabIndex = 17;
            this.dgv_AccountCharges.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_AccountCharges_CellBeginEdit);
            this.dgv_AccountCharges.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_AccountCharges_CellEndEdit);
            this.dgv_AccountCharges.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_AccountCharges_EditingControlShowing);
            // 
            // ApplyCreditsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(812, 465);
            this.Controls.Add(this.dgv_AccountCharges);
            this.Controls.Add(this.dgv_CreditTransaction);
            this.Controls.Add(this.cb_Currency);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Distribute);
            this.Controls.Add(this.txt_Balance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Mode);
            this.Controls.Add(this.label_Mode);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplyCreditsScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApplyCreditsScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ApplyCreditsScreen_FormClosed);
            this.Load += new System.EventHandler(this.ApplyCreditsScreen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CreditTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AccountCharges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rd_Batch;
        private System.Windows.Forms.RadioButton rd_Credits;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label_Mode;
        private System.Windows.Forms.TextBox txt_Mode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Balance;
        private System.Windows.Forms.Button btn_Distribute;
        private System.Windows.Forms.Button btn_Save;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.RadioButton rd_VendorCode;
        //private System.Windows.Forms.DataGridViewTextBoxColumn invoiceAmountFCDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn taxValueFCDataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn invoiceAmountFCDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn taxValueFCDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Currency;
        private System.Windows.Forms.DataGridView dgv_CreditTransaction;
        private System.Windows.Forms.DataGridView dgv_AccountCharges;
    }
}