
namespace Accounting_GeneralLedger.Forms
{
    partial class ChooseName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseName));
            this.button1 = new System.Windows.Forms.Button();
            this.txt_AccountNumber1 = new System.Windows.Forms.TextBox();
            this.btn_SelectCurrentRecord = new System.Windows.Forms.Button();
            this.checkBox_Active = new System.Windows.Forms.CheckBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.AccountType = new System.Windows.Forms.ComboBox();
            this.txt_AccountName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LightGray;
            this.button1.Location = new System.Drawing.Point(527, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 46);
            this.button1.TabIndex = 24;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txt_AccountNumber1
            // 
            this.txt_AccountNumber1.Location = new System.Drawing.Point(313, 24);
            this.txt_AccountNumber1.Name = "txt_AccountNumber1";
            this.txt_AccountNumber1.Size = new System.Drawing.Size(209, 20);
            this.txt_AccountNumber1.TabIndex = 16;
            // 
            // btn_SelectCurrentRecord
            // 
            this.btn_SelectCurrentRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(53)))), ((int)(((byte)(73)))));
            this.btn_SelectCurrentRecord.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btn_SelectCurrentRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_SelectCurrentRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btn_SelectCurrentRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectCurrentRecord.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SelectCurrentRecord.ForeColor = System.Drawing.Color.LightGray;
            this.btn_SelectCurrentRecord.Location = new System.Drawing.Point(136, 381);
            this.btn_SelectCurrentRecord.Name = "btn_SelectCurrentRecord";
            this.btn_SelectCurrentRecord.Size = new System.Drawing.Size(222, 46);
            this.btn_SelectCurrentRecord.TabIndex = 22;
            this.btn_SelectCurrentRecord.Text = "Select Current Record";
            this.btn_SelectCurrentRecord.UseVisualStyleBackColor = false;
            this.btn_SelectCurrentRecord.Click += new System.EventHandler(this.btn_SelectCurrentRecord_Click);
            // 
            // checkBox_Active
            // 
            this.checkBox_Active.AutoSize = true;
            this.checkBox_Active.Location = new System.Drawing.Point(313, 106);
            this.checkBox_Active.Name = "checkBox_Active";
            this.checkBox_Active.Size = new System.Drawing.Size(150, 17);
            this.checkBox_Active.TabIndex = 21;
            this.checkBox_Active.Text = "Include Inactive Accounts";
            this.checkBox_Active.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.DataMember = "GLAccounts";
            this.dgv.Location = new System.Drawing.Point(109, 134);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(578, 218);
            this.dgv.TabIndex = 19;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // AccountType
            // 
            this.AccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountType.FormattingEnabled = true;
            this.AccountType.Location = new System.Drawing.Point(313, 79);
            this.AccountType.Name = "AccountType";
            this.AccountType.Size = new System.Drawing.Size(208, 21);
            this.AccountType.TabIndex = 18;
            // 
            // txt_AccountName
            // 
            this.txt_AccountName.Location = new System.Drawing.Point(313, 50);
            this.txt_AccountName.Name = "txt_AccountName";
            this.txt_AccountName.Size = new System.Drawing.Size(208, 20);
            this.txt_AccountName.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Account Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Account Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Account Number";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(588, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // ChooseName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(769, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_AccountNumber1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_SelectCurrentRecord);
            this.Controls.Add(this.checkBox_Active);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.AccountType);
            this.Controls.Add(this.txt_AccountName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChooseName";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_AccountNumber1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_SelectCurrentRecord;
        private System.Windows.Forms.CheckBox checkBox_Active;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox AccountType;
        private System.Windows.Forms.TextBox txt_AccountName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}