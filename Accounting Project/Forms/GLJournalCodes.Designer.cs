namespace Accounting_GeneralLedger
{
    partial class GLJournalCodes
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.txt_JournalCodeID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJournalDescription = new System.Windows.Forms.TextBox();
            this.txtJournalCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Lock53 = new System.Windows.Forms.GroupBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.Lock52 = new System.Windows.Forms.GroupBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.Btnsaveedit = new System.Windows.Forms.Button();
            this.Lock51 = new System.Windows.Forms.GroupBox();
            this.btn_New = new System.Windows.Forms.Button();
            this.btnSavenew = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnundo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.GB1.SuspendLayout();
            this.Lock53.SuspendLayout();
            this.Lock52.SuspendLayout();
            this.Lock51.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 2);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(233, 172);
            this.dgv.TabIndex = 5;
            this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(587, 24);
            this.menuStrip1.TabIndex = 6;
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
            this.insertToolStripMenuItem.Text = "Insert ";
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
            // GB1
            // 
            this.GB1.Controls.Add(this.txt_JournalCodeID);
            this.GB1.Controls.Add(this.label3);
            this.GB1.Controls.Add(this.label2);
            this.GB1.Controls.Add(this.txtJournalDescription);
            this.GB1.Controls.Add(this.txtJournalCode);
            this.GB1.Controls.Add(this.label1);
            this.GB1.Enabled = false;
            this.GB1.Location = new System.Drawing.Point(264, 24);
            this.GB1.Name = "GB1";
            this.GB1.Size = new System.Drawing.Size(311, 114);
            this.GB1.TabIndex = 28;
            this.GB1.TabStop = false;
            // 
            // txt_JournalCodeID
            // 
            this.txt_JournalCodeID.Location = new System.Drawing.Point(141, 15);
            this.txt_JournalCodeID.Name = "txt_JournalCodeID";
            this.txt_JournalCodeID.ReadOnly = true;
            this.txt_JournalCodeID.Size = new System.Drawing.Size(104, 20);
            this.txt_JournalCodeID.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Journal Code ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Journal Description";
            // 
            // txtJournalDescription
            // 
            this.txtJournalDescription.Location = new System.Drawing.Point(141, 83);
            this.txtJournalDescription.MaxLength = 50;
            this.txtJournalDescription.Name = "txtJournalDescription";
            this.txtJournalDescription.Size = new System.Drawing.Size(157, 20);
            this.txtJournalDescription.TabIndex = 12;
            // 
            // txtJournalCode
            // 
            this.txtJournalCode.Location = new System.Drawing.Point(141, 48);
            this.txtJournalCode.MaxLength = 10;
            this.txtJournalCode.Name = "txtJournalCode";
            this.txtJournalCode.Size = new System.Drawing.Size(157, 20);
            this.txtJournalCode.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Journal Code";
            // 
            // Lock53
            // 
            this.Lock53.Controls.Add(this.btndelete);
            this.Lock53.Location = new System.Drawing.Point(275, 180);
            this.Lock53.Name = "Lock53";
            this.Lock53.Size = new System.Drawing.Size(69, 37);
            this.Lock53.TabIndex = 33;
            this.Lock53.TabStop = false;
            this.Lock53.Tag = "53";
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
            // Lock52
            // 
            this.Lock52.Controls.Add(this.Btnsaveedit);
            this.Lock52.Location = new System.Drawing.Point(171, 180);
            this.Lock52.Name = "Lock52";
            this.Lock52.Size = new System.Drawing.Size(69, 37);
            this.Lock52.TabIndex = 34;
            this.Lock52.TabStop = false;
            this.Lock52.Tag = "52";
            // 
            // btnedit
            // 
            this.btnedit.Enabled = false;
            this.btnedit.Location = new System.Drawing.Point(142, 149);
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
            // Lock51
            // 
            this.Lock51.Controls.Add(this.btnSavenew);
            this.Lock51.Location = new System.Drawing.Point(67, 180);
            this.Lock51.Name = "Lock51";
            this.Lock51.Size = new System.Drawing.Size(69, 37);
            this.Lock51.TabIndex = 35;
            this.Lock51.TabStop = false;
            this.Lock51.Tag = "51";
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(-30, 171);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(69, 31);
            this.btn_New.TabIndex = 16;
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
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(483, 186);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(69, 31);
            this.btnexit.TabIndex = 61;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnundo
            // 
            this.btnundo.Location = new System.Drawing.Point(379, 186);
            this.btnundo.Name = "btnundo";
            this.btnundo.Size = new System.Drawing.Size(69, 31);
            this.btnundo.TabIndex = 60;
            this.btnundo.Text = "Undo";
            this.btnundo.UseVisualStyleBackColor = true;
            this.btnundo.Click += new System.EventHandler(this.btnundo_Click);
            // 
            // GLJournalCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(587, 225);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnundo);
            this.Controls.Add(this.Lock51);
            this.Controls.Add(this.Lock52);
            this.Controls.Add(this.Lock53);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.GB1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GLJournalCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GLJournalCodes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GLJournalCodes_FormClosing);
            this.Load += new System.EventHandler(this.GLJournalCodes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GB1.ResumeLayout(false);
            this.GB1.PerformLayout();
            this.Lock53.ResumeLayout(false);
            this.Lock52.ResumeLayout(false);
            this.Lock51.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        //private System.Windows.Forms.DataGridViewTextBoxColumn journalCodeDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn journalDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private System.Windows.Forms.GroupBox GB1;
        private System.Windows.Forms.TextBox txt_JournalCodeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJournalDescription;
        private System.Windows.Forms.TextBox txtJournalCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Lock51;
        private System.Windows.Forms.GroupBox Lock52;
        private System.Windows.Forms.GroupBox Lock53;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnundo;
        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btnSavenew;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button Btnsaveedit;
        private System.Windows.Forms.Button btndelete;
    }
}