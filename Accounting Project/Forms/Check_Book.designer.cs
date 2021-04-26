namespace Accounting_GeneralLedger
{
    partial class Check_Book
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_New = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Bank_Account_ID = new System.Windows.Forms.ComboBox();
            this.lbl_Bank_Account_ID = new System.Windows.Forms.Label();
            this.lbl_To_Serial = new System.Windows.Forms.Label();
            this.txt_To_Serial = new System.Windows.Forms.TextBox();
            this.lbl_From_Serial = new System.Windows.Forms.Label();
            this.txt_From_Serial = new System.Windows.Forms.TextBox();
            this.lbl_Check_Book_ID = new System.Windows.Forms.Label();
            this.txt_Check_Book_ID = new System.Windows.Forms.TextBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.Lock88 = new System.Windows.Forms.GroupBox();
            this.Lock90 = new System.Windows.Forms.GroupBox();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Lock88.SuspendLayout();
            this.Lock90.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(2, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(375, 187);
            this.dgv.TabIndex = 7;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(0, 6);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(69, 31);
            this.btn_New.TabIndex = 16;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_Bank_Account_ID);
            this.groupBox1.Controls.Add(this.lbl_Bank_Account_ID);
            this.groupBox1.Controls.Add(this.lbl_To_Serial);
            this.groupBox1.Controls.Add(this.txt_To_Serial);
            this.groupBox1.Controls.Add(this.lbl_From_Serial);
            this.groupBox1.Controls.Add(this.txt_From_Serial);
            this.groupBox1.Controls.Add(this.lbl_Check_Book_ID);
            this.groupBox1.Controls.Add(this.txt_Check_Book_ID);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(383, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 187);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.EnabledChanged += new System.EventHandler(this.groupBox1_EnabledChanged);
            // 
            // cb_Bank_Account_ID
            // 
            this.cb_Bank_Account_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Bank_Account_ID.FormattingEnabled = true;
            this.cb_Bank_Account_ID.Location = new System.Drawing.Point(112, 54);
            this.cb_Bank_Account_ID.Name = "cb_Bank_Account_ID";
            this.cb_Bank_Account_ID.Size = new System.Drawing.Size(160, 21);
            this.cb_Bank_Account_ID.TabIndex = 43;
            // 
            // lbl_Bank_Account_ID
            // 
            this.lbl_Bank_Account_ID.AutoSize = true;
            this.lbl_Bank_Account_ID.Location = new System.Drawing.Point(8, 57);
            this.lbl_Bank_Account_ID.Name = "lbl_Bank_Account_ID";
            this.lbl_Bank_Account_ID.Size = new System.Drawing.Size(75, 13);
            this.lbl_Bank_Account_ID.TabIndex = 42;
            this.lbl_Bank_Account_ID.Text = "Bank Account";
            // 
            // lbl_To_Serial
            // 
            this.lbl_To_Serial.AutoSize = true;
            this.lbl_To_Serial.Location = new System.Drawing.Point(8, 130);
            this.lbl_To_Serial.Name = "lbl_To_Serial";
            this.lbl_To_Serial.Size = new System.Drawing.Size(49, 13);
            this.lbl_To_Serial.TabIndex = 41;
            this.lbl_To_Serial.Text = "To Serial";
            // 
            // txt_To_Serial
            // 
            this.txt_To_Serial.Location = new System.Drawing.Point(112, 127);
            this.txt_To_Serial.MaxLength = 50;
            this.txt_To_Serial.Name = "txt_To_Serial";
            this.txt_To_Serial.Size = new System.Drawing.Size(106, 20);
            this.txt_To_Serial.TabIndex = 40;
            this.txt_To_Serial.Text = "0";
            this.txt_To_Serial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_To_Serial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_To_Serial_KeyPress);
            // 
            // lbl_From_Serial
            // 
            this.lbl_From_Serial.AutoSize = true;
            this.lbl_From_Serial.Location = new System.Drawing.Point(8, 95);
            this.lbl_From_Serial.Name = "lbl_From_Serial";
            this.lbl_From_Serial.Size = new System.Drawing.Size(59, 13);
            this.lbl_From_Serial.TabIndex = 39;
            this.lbl_From_Serial.Text = "From Serial";
            // 
            // txt_From_Serial
            // 
            this.txt_From_Serial.Location = new System.Drawing.Point(112, 92);
            this.txt_From_Serial.MaxLength = 50;
            this.txt_From_Serial.Name = "txt_From_Serial";
            this.txt_From_Serial.Size = new System.Drawing.Size(106, 20);
            this.txt_From_Serial.TabIndex = 38;
            this.txt_From_Serial.Text = "0";
            this.txt_From_Serial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_From_Serial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_To_Serial_KeyPress);
            // 
            // lbl_Check_Book_ID
            // 
            this.lbl_Check_Book_ID.AutoSize = true;
            this.lbl_Check_Book_ID.Location = new System.Drawing.Point(8, 22);
            this.lbl_Check_Book_ID.Name = "lbl_Check_Book_ID";
            this.lbl_Check_Book_ID.Size = new System.Drawing.Size(80, 13);
            this.lbl_Check_Book_ID.TabIndex = 21;
            this.lbl_Check_Book_ID.Text = "Check Book ID";
            // 
            // txt_Check_Book_ID
            // 
            this.txt_Check_Book_ID.Location = new System.Drawing.Point(112, 19);
            this.txt_Check_Book_ID.Name = "txt_Check_Book_ID";
            this.txt_Check_Book_ID.ReadOnly = true;
            this.txt_Check_Book_ID.Size = new System.Drawing.Size(86, 20);
            this.txt_Check_Book_ID.TabIndex = 20;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(586, 216);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(69, 31);
            this.btnexit.TabIndex = 56;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnundo
            // 
            this.btnundo.Location = new System.Drawing.Point(478, 216);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(69, 31);
            this.btnundo.TabIndex = 55;
            this.btnundo.Text = "Undo";
            this.btnundo.UseVisualStyleBackColor = true;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
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
            // Lock88
            // 
            this.Lock88.Controls.Add(this.btn_New);
            this.Lock88.Controls.Add(this.btnSavenew);
            this.Lock88.Location = new System.Drawing.Point(262, 209);
            this.Lock88.Name = "Lock88";
            this.Lock88.Size = new System.Drawing.Size(69, 37);
            this.Lock88.TabIndex = 28;
            this.Lock88.TabStop = false;
            this.Lock88.Tag = "88";
            this.Lock88.Enter += new System.EventHandler(this.Lock88_Enter);
            // 
            // Lock90
            // 
            this.Lock90.Controls.Add(this.btndelete);
            this.Lock90.Location = new System.Drawing.Point(370, 209);
            this.Lock90.Name = "Lock90";
            this.Lock90.Size = new System.Drawing.Size(69, 37);
            this.Lock90.TabIndex = 57;
            this.Lock90.TabStop = false;
            this.Lock90.Tag = "90";
            this.Lock90.Enter += new System.EventHandler(this.Lock90_Enter);
            // 
            // dbAccountingProjectDSBindingSource
            // 
            this.dbAccountingProjectDSBindingSource.DataSource = this.dbAccountingProjectDS;
            this.dbAccountingProjectDSBindingSource.Position = 0;
            // 
            // dbAccountingProjectDS
            // 
            this.dbAccountingProjectDS.DataSetName = "dbAccountingProjectDS";
            this.dbAccountingProjectDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Check_Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(685, 259);
            this.ControlBox = false;
            this.Controls.Add(this.Lock90);
            this.Controls.Add(this.Lock88);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Check_Book";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Book";
            this.Load += new System.EventHandler(this.Check_Book_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Lock88.ResumeLayout(false);
            this.Lock90.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Check_Book_ID;
        private System.Windows.Forms.TextBox txt_Check_Book_ID;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.GroupBox Lock90;
        private System.Windows.Forms.GroupBox Lock88;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lbl_To_Serial;
        private System.Windows.Forms.TextBox txt_To_Serial;
        private System.Windows.Forms.Label lbl_From_Serial;
        private System.Windows.Forms.TextBox txt_From_Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkBookIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankAccountIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromSerialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toSerialDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cb_Bank_Account_ID;
        private System.Windows.Forms.Label lbl_Bank_Account_ID;
    }
}