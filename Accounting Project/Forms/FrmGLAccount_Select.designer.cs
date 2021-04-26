namespace Accounting_GeneralLedger
{
    partial class FrmGLAccount_Select
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbl_FAccountNumber = new System.Windows.Forms.Label();
            this.txt_FAccountNumber = new System.Windows.Forms.MaskedTextBox();
            this.lbl_TAccountNumber = new System.Windows.Forms.Label();
            this.txt_TAccountNumber = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(137, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 46);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(159)))), ((int)(((byte)(127)))));
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(118)))), ((int)(((byte)(126)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.LightGray;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOk.Location = new System.Drawing.Point(256, 97);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 46);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lbl_FAccountNumber
            // 
            this.lbl_FAccountNumber.AutoSize = true;
            this.lbl_FAccountNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FAccountNumber.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_FAccountNumber.Location = new System.Drawing.Point(12, 18);
            this.lbl_FAccountNumber.Name = "lbl_FAccountNumber";
            this.lbl_FAccountNumber.Size = new System.Drawing.Size(155, 17);
            this.lbl_FAccountNumber.TabIndex = 22;
            this.lbl_FAccountNumber.Text = "From Account Number";
            // 
            // txt_FAccountNumber
            // 
            this.txt_FAccountNumber.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FAccountNumber.Location = new System.Drawing.Point(182, 15);
            this.txt_FAccountNumber.Name = "txt_FAccountNumber";
            this.txt_FAccountNumber.PromptChar = '%';
            this.txt_FAccountNumber.Size = new System.Drawing.Size(166, 22);
            this.txt_FAccountNumber.TabIndex = 23;
            this.txt_FAccountNumber.DoubleClick += new System.EventHandler(this.txt_FAccountNumber_DoubleClick);
            // 
            // lbl_TAccountNumber
            // 
            this.lbl_TAccountNumber.AutoSize = true;
            this.lbl_TAccountNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TAccountNumber.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_TAccountNumber.Location = new System.Drawing.Point(12, 56);
            this.lbl_TAccountNumber.Name = "lbl_TAccountNumber";
            this.lbl_TAccountNumber.Size = new System.Drawing.Size(137, 17);
            this.lbl_TAccountNumber.TabIndex = 24;
            this.lbl_TAccountNumber.Text = "To Account Number";
            // 
            // txt_TAccountNumber
            // 
            this.txt_TAccountNumber.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TAccountNumber.Location = new System.Drawing.Point(182, 53);
            this.txt_TAccountNumber.Name = "txt_TAccountNumber";
            this.txt_TAccountNumber.PromptChar = '%';
            this.txt_TAccountNumber.Size = new System.Drawing.Size(166, 22);
            this.txt_TAccountNumber.TabIndex = 25;
            this.txt_TAccountNumber.DoubleClick += new System.EventHandler(this.txt_TAccountNumber_DoubleClick);
            // 
            // FrmGLAccount_Select
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(364, 165);
            this.Controls.Add(this.lbl_TAccountNumber);
            this.Controls.Add(this.txt_TAccountNumber);
            this.Controls.Add(this.lbl_FAccountNumber);
            this.Controls.Add(this.txt_FAccountNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGLAccount_Select";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G/L Accounts Selection";
            this.Load += new System.EventHandler(this.FrmGLAccount_Select_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lbl_FAccountNumber;
        private System.Windows.Forms.MaskedTextBox txt_FAccountNumber;
        private System.Windows.Forms.Label lbl_TAccountNumber;
        private System.Windows.Forms.MaskedTextBox txt_TAccountNumber;
    }
}