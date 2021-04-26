namespace Accounting_GeneralLedger
{
    partial class SearchCustomer
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
            this.cb_Status = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_AccountName = new System.Windows.Forms.TextBox();
            this.txt_AccountCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_Status
            // 
            this.cb_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Status.FormattingEnabled = true;
            this.cb_Status.Items.AddRange(new object[] {
            " ",
            "P",
            "S"});
            this.cb_Status.Location = new System.Drawing.Point(158, 64);
            this.cb_Status.Name = "cb_Status";
            this.cb_Status.Size = new System.Drawing.Size(45, 21);
            this.cb_Status.TabIndex = 11;
            this.cb_Status.SelectedIndexChanged += new System.EventHandler(this.cb_Status_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Account Name";
            // 
            // txt_AccountName
            // 
            this.txt_AccountName.Location = new System.Drawing.Point(158, 38);
            this.txt_AccountName.Name = "txt_AccountName";
            this.txt_AccountName.Size = new System.Drawing.Size(176, 20);
            this.txt_AccountName.TabIndex = 8;
            this.txt_AccountName.TextChanged += new System.EventHandler(this.txt_AccountName_TextChanged);
            // 
            // txt_AccountCode
            // 
            this.txt_AccountCode.Location = new System.Drawing.Point(158, 12);
            this.txt_AccountCode.Name = "txt_AccountCode";
            this.txt_AccountCode.Size = new System.Drawing.Size(176, 20);
            this.txt_AccountCode.TabIndex = 7;
            this.txt_AccountCode.TextChanged += new System.EventHandler(this.txt_AccountCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Account Code";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 91);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(481, 215);
            this.dgv.TabIndex = 12;
            this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
            // 
            // SearchCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(481, 306);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cb_Status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_AccountName);
            this.Controls.Add(this.txt_AccountCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchCustomer";
            this.Text = "SearchCustomer";
            this.Load += new System.EventHandler(this.SearchCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.ComboBox cb_Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_AccountName;
        private System.Windows.Forms.TextBox txt_AccountCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
    }
}