namespace Accounting_GeneralLedger
{
    partial class Bank_Deposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bank_Deposit));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            this.PageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.batchTempBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_NetDeposit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Period = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DTP_JVDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_JVDescription = new System.Windows.Forms.TextBox();
            this.cb_Bank_Deposit_Type = new System.Windows.Forms.ComboBox();
            this.lbl_Bank_Deposit_Type = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lblCredit_Fees = new System.Windows.Forms.Label();
            this.txtCash_Fees = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReceipt_Amt = new System.Windows.Forms.TextBox();
            this.lblCashOverSort = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchTempBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PrintDialog1
            // 
            this.PrintDialog1.Document = this.PrintDocument1;
            // 
            // PageSetupDialog1
            // 
            this.PageSetupDialog1.Document = this.PrintDocument1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(697, 228);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(114, 51);
            this.btnExit.TabIndex = 50;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Image = global::Accounting_GeneralLedger.Properties.Resources.undo;
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndo.Location = new System.Drawing.Point(559, 228);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(114, 51);
            this.btnUndo.TabIndex = 42;
            this.btnUndo.Text = "Undo";
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // txt_NetDeposit
            // 
            this.txt_NetDeposit.BackColor = System.Drawing.Color.White;
            this.txt_NetDeposit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NetDeposit.Location = new System.Drawing.Point(236, 133);
            this.txt_NetDeposit.Name = "txt_NetDeposit";
            this.txt_NetDeposit.ReadOnly = true;
            this.txt_NetDeposit.Size = new System.Drawing.Size(122, 30);
            this.txt_NetDeposit.TabIndex = 21;
            this.txt_NetDeposit.Text = "0";
            this.txt_NetDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(95, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "Net Deposit =";
            // 
            // txt_Period
            // 
            this.txt_Period.BackColor = System.Drawing.Color.White;
            this.txt_Period.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Period.Location = new System.Drawing.Point(343, 66);
            this.txt_Period.Name = "txt_Period";
            this.txt_Period.ReadOnly = true;
            this.txt_Period.Size = new System.Drawing.Size(81, 22);
            this.txt_Period.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(292, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Period";
            // 
            // DTP_JVDate
            // 
            this.DTP_JVDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_JVDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_JVDate.Location = new System.Drawing.Point(147, 66);
            this.DTP_JVDate.Name = "DTP_JVDate";
            this.DTP_JVDate.Size = new System.Drawing.Size(136, 22);
            this.DTP_JVDate.TabIndex = 8;
            this.DTP_JVDate.CloseUp += new System.EventHandler(this.DTP_JVDate_CloseUp);
            this.DTP_JVDate.ValueChanged += new System.EventHandler(this.DTP_JVDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Post Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ref #";
            // 
            // txt_JVDescription
            // 
            this.txt_JVDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_JVDescription.Location = new System.Drawing.Point(147, 102);
            this.txt_JVDescription.Multiline = true;
            this.txt_JVDescription.Name = "txt_JVDescription";
            this.txt_JVDescription.Size = new System.Drawing.Size(277, 64);
            this.txt_JVDescription.TabIndex = 3;
            // 
            // cb_Bank_Deposit_Type
            // 
            this.cb_Bank_Deposit_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Bank_Deposit_Type.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Bank_Deposit_Type.FormattingEnabled = true;
            this.cb_Bank_Deposit_Type.Location = new System.Drawing.Point(147, 32);
            this.cb_Bank_Deposit_Type.Name = "cb_Bank_Deposit_Type";
            this.cb_Bank_Deposit_Type.Size = new System.Drawing.Size(180, 24);
            this.cb_Bank_Deposit_Type.TabIndex = 52;
            this.cb_Bank_Deposit_Type.SelectedIndexChanged += new System.EventHandler(this.cb_Bank_Deposit_Type_SelectedIndexChanged);
            // 
            // lbl_Bank_Deposit_Type
            // 
            this.lbl_Bank_Deposit_Type.AutoSize = true;
            this.lbl_Bank_Deposit_Type.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Bank_Deposit_Type.Location = new System.Drawing.Point(19, 36);
            this.lbl_Bank_Deposit_Type.Name = "lbl_Bank_Deposit_Type";
            this.lbl_Bank_Deposit_Type.Size = new System.Drawing.Size(117, 16);
            this.lbl_Bank_Deposit_Type.TabIndex = 51;
            this.lbl_Bank_Deposit_Type.Text = "Bank Deposit Type";
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(421, 228);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(114, 51);
            this.btn_Save.TabIndex = 53;
            this.btn_Save.Text = "Save ";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lblCredit_Fees
            // 
            this.lblCredit_Fees.AutoSize = true;
            this.lblCredit_Fees.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredit_Fees.Location = new System.Drawing.Point(25, 61);
            this.lblCredit_Fees.Name = "lblCredit_Fees";
            this.lblCredit_Fees.Size = new System.Drawing.Size(195, 23);
            this.lblCredit_Fees.TabIndex = 54;
            this.lblCredit_Fees.Text = "Credit Card bank Fees";
            this.lblCredit_Fees.Visible = false;
            // 
            // txtCash_Fees
            // 
            this.txtCash_Fees.BackColor = System.Drawing.Color.White;
            this.txtCash_Fees.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash_Fees.Location = new System.Drawing.Point(236, 57);
            this.txtCash_Fees.Name = "txtCash_Fees";
            this.txtCash_Fees.ReadOnly = true;
            this.txtCash_Fees.Size = new System.Drawing.Size(122, 30);
            this.txtCash_Fees.TabIndex = 55;
            this.txtCash_Fees.Text = "0";
            this.txtCash_Fees.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCash_Fees.TextChanged += new System.EventHandler(this.txtCash_Fees_TextChanged);
            this.txtCash_Fees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_Fees_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 23);
            this.label3.TabIndex = 56;
            this.label3.Text = "Receipts Amount";
            // 
            // txtReceipt_Amt
            // 
            this.txtReceipt_Amt.BackColor = System.Drawing.Color.White;
            this.txtReceipt_Amt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceipt_Amt.Location = new System.Drawing.Point(236, 15);
            this.txtReceipt_Amt.Name = "txtReceipt_Amt";
            this.txtReceipt_Amt.Size = new System.Drawing.Size(122, 30);
            this.txtReceipt_Amt.TabIndex = 57;
            this.txtReceipt_Amt.Text = "0";
            this.txtReceipt_Amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReceipt_Amt.TextChanged += new System.EventHandler(this.txtReceipt_Amt_TextChanged);
            this.txtReceipt_Amt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceipt_Amt_KeyPress);
            // 
            // lblCashOverSort
            // 
            this.lblCashOverSort.AutoSize = true;
            this.lblCashOverSort.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashOverSort.Location = new System.Drawing.Point(74, 61);
            this.lblCashOverSort.Name = "lblCashOverSort";
            this.lblCashOverSort.Size = new System.Drawing.Size(146, 23);
            this.lblCashOverSort.TabIndex = 58;
            this.lblCashOverSort.Text = "Cash Over Short";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtReceipt_Amt);
            this.groupBox1.Controls.Add(this.lblCashOverSort);
            this.groupBox1.Controls.Add(this.txt_NetDeposit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCash_Fees);
            this.groupBox1.Controls.Add(this.lblCredit_Fees);
            this.groupBox1.Location = new System.Drawing.Point(430, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 180);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label6.Location = new System.Drawing.Point(6, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(370, 23);
            this.label6.TabIndex = 59;
            this.label6.Text = "____________________________________";
            // 
            // Bank_Deposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(820, 291);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.cb_Bank_Deposit_Type);
            this.Controls.Add(this.lbl_Bank_Deposit_Type);
            this.Controls.Add(this.txt_JVDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Period);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.DTP_JVDate);
            this.Controls.Add(this.btnUndo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Bank_Deposit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Deposit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bank_Deposit_FormClosed);
            this.Load += new System.EventHandler(this.Bank_Deposit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchTempBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PrintDialog PrintDialog1;
        private System.Windows.Forms.PageSetupDialog PageSetupDialog1;
        private System.Drawing.Printing.PrintDocument PrintDocument1;
        private System.Windows.Forms.BindingSource batchTempBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txt_JVDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_NetDeposit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Period;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTP_JVDate;
        private System.Windows.Forms.ComboBox cb_Bank_Deposit_Type;
        private System.Windows.Forms.Label lbl_Bank_Deposit_Type;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lblCashOverSort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReceipt_Amt;
        private System.Windows.Forms.Label lblCredit_Fees;
        private System.Windows.Forms.TextBox txtCash_Fees;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
    }
}