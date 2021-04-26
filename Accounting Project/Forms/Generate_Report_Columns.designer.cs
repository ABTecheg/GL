namespace Accounting_GeneralLedger
{
    partial class Generate_Report_Columns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generate_Report_Columns));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
            this.PageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_UserID = new System.Windows.Forms.TextBox();
            this.txtCol_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCol_Code = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.chkactive = new System.Windows.Forms.CheckBox();
            this.txtCol_Code = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.Lock59 = new System.Windows.Forms.GroupBox();
            this.Lock58 = new System.Windows.Forms.GroupBox();
            this.Lock57 = new System.Windows.Forms.GroupBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Col_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Header = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Calc_Formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Prec_Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Sup = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Col_Calc_Divide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Lock59.SuspendLayout();
            this.Lock58.SuspendLayout();
            this.Lock57.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(0, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 46);
            this.btnEdit.TabIndex = 49;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveEdit.Image")));
            this.btnSaveEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveEdit.Location = new System.Drawing.Point(0, 6);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(98, 46);
            this.btnSaveEdit.TabIndex = 51;
            this.btnSaveEdit.Text = "Save";
            this.btnSaveEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveEdit.UseVisualStyleBackColor = true;
            this.btnSaveEdit.Visible = false;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(0, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 46);
            this.btnDelete.TabIndex = 48;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // PrintDialog1
            // 
            this.PrintDialog1.Document = this.PrintDocument1;
            // 
            // PageSetupDialog1
            // 
            this.PageSetupDialog1.Document = this.PrintDocument1;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(0, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(98, 46);
            this.btnNew.TabIndex = 44;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNew.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveNew.Image")));
            this.btnSaveNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveNew.Location = new System.Drawing.Point(0, 6);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(98, 46);
            this.btnSaveNew.TabIndex = 43;
            this.btnSaveNew.Text = "Save";
            this.btnSaveNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Visible = false;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(494, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "User ID";
            // 
            // txt_UserID
            // 
            this.txt_UserID.BackColor = System.Drawing.Color.White;
            this.txt_UserID.Location = new System.Drawing.Point(543, 13);
            this.txt_UserID.MaxLength = 30;
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.ReadOnly = true;
            this.txt_UserID.Size = new System.Drawing.Size(103, 20);
            this.txt_UserID.TabIndex = 71;
            // 
            // txtCol_Name
            // 
            this.txtCol_Name.Location = new System.Drawing.Point(215, 13);
            this.txtCol_Name.Name = "txtCol_Name";
            this.txtCol_Name.Size = new System.Drawing.Size(275, 20);
            this.txtCol_Name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // lblCol_Code
            // 
            this.lblCol_Code.AutoSize = true;
            this.lblCol_Code.Location = new System.Drawing.Point(10, 17);
            this.lblCol_Code.Name = "lblCol_Code";
            this.lblCol_Code.Size = new System.Drawing.Size(32, 13);
            this.lblCol_Code.TabIndex = 29;
            this.lblCol_Code.Text = "Code";
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Image = global::Accounting_GeneralLedger.Properties.Resources.undo;
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndo.Location = new System.Drawing.Point(664, 350);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(98, 46);
            this.btnUndo.TabIndex = 84;
            this.btnUndo.Text = "Undo";
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = global::Accounting_GeneralLedger.Properties.Resources.find;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(380, 7);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(98, 31);
            this.btnFind.TabIndex = 82;
            this.btnFind.Text = "Find";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.chkactive);
            this.groupDetails.Controls.Add(this.lblCol_Code);
            this.groupDetails.Controls.Add(this.txtCol_Name);
            this.groupDetails.Controls.Add(this.label7);
            this.groupDetails.Controls.Add(this.label2);
            this.groupDetails.Controls.Add(this.txt_UserID);
            this.groupDetails.Controls.Add(this.txtCol_Code);
            this.groupDetails.Enabled = false;
            this.groupDetails.Location = new System.Drawing.Point(5, 49);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(728, 48);
            this.groupDetails.TabIndex = 95;
            this.groupDetails.TabStop = false;
            this.groupDetails.EnabledChanged += new System.EventHandler(this.groupDetails_EnabledChanged);
            // 
            // chkactive
            // 
            this.chkactive.AutoSize = true;
            this.chkactive.Location = new System.Drawing.Point(652, 15);
            this.chkactive.Name = "chkactive";
            this.chkactive.Size = new System.Drawing.Size(56, 17);
            this.chkactive.TabIndex = 75;
            this.chkactive.Text = "Active";
            this.chkactive.UseVisualStyleBackColor = true;
            // 
            // txtCol_Code
            // 
            this.txtCol_Code.Enabled = false;
            this.txtCol_Code.Location = new System.Drawing.Point(50, 13);
            this.txtCol_Code.Name = "txtCol_Code";
            this.txtCol_Code.Size = new System.Drawing.Size(79, 20);
            this.txtCol_Code.TabIndex = 30;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(799, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(782, 350);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 46);
            this.btnExit.TabIndex = 87;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Lock59
            // 
            this.Lock59.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lock59.Controls.Add(this.btnDelete);
            this.Lock59.Location = new System.Drawing.Point(546, 344);
            this.Lock59.Name = "Lock59";
            this.Lock59.Size = new System.Drawing.Size(98, 52);
            this.Lock59.TabIndex = 91;
            this.Lock59.TabStop = false;
            this.Lock59.Tag = "59";
            // 
            // Lock58
            // 
            this.Lock58.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lock58.Controls.Add(this.btnEdit);
            this.Lock58.Controls.Add(this.btnSaveEdit);
            this.Lock58.Location = new System.Drawing.Point(428, 344);
            this.Lock58.Name = "Lock58";
            this.Lock58.Size = new System.Drawing.Size(98, 52);
            this.Lock58.TabIndex = 92;
            this.Lock58.TabStop = false;
            this.Lock58.Tag = "58";
            // 
            // Lock57
            // 
            this.Lock57.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lock57.Controls.Add(this.btnNew);
            this.Lock57.Controls.Add(this.btnSaveNew);
            this.Lock57.Location = new System.Drawing.Point(310, 344);
            this.Lock57.Name = "Lock57";
            this.Lock57.Size = new System.Drawing.Size(98, 52);
            this.Lock57.TabIndex = 93;
            this.Lock57.TabStop = false;
            this.Lock57.Tag = "57";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(271, 12);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(100, 20);
            this.txtFind.TabIndex = 83;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // dgv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_No,
            this.Col_Type,
            this.Col_Source,
            this.Col_Range,
            this.Col_Period,
            this.Col_Header,
            this.Col_Calc_Formula,
            this.Col_Prec_Source,
            this.Col_Width,
            this.Col_Sup,
            this.Col_Calc_Divide});
            this.dgv.Enabled = false;
            this.dgv.Location = new System.Drawing.Point(5, 103);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 25;
            this.dgv.Size = new System.Drawing.Size(898, 235);
            this.dgv.TabIndex = 81;
            this.dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_CellBeginEdit);
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
            this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_RowsAdded);
            this.dgv.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgv_RowsRemoved);
            // 
            // Col_No
            // 
            this.Col_No.HeaderText = "Column";
            this.Col_No.Name = "Col_No";
            this.Col_No.ReadOnly = true;
            this.Col_No.Width = 67;
            // 
            // Col_Type
            // 
            this.Col_Type.HeaderText = "Type";
            this.Col_Type.Name = "Col_Type";
            this.Col_Type.ReadOnly = true;
            this.Col_Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_Type.Width = 56;
            // 
            // Col_Source
            // 
            this.Col_Source.HeaderText = "Source";
            this.Col_Source.Name = "Col_Source";
            this.Col_Source.ReadOnly = true;
            this.Col_Source.Width = 66;
            // 
            // Col_Range
            // 
            this.Col_Range.HeaderText = "Range";
            this.Col_Range.Name = "Col_Range";
            this.Col_Range.ReadOnly = true;
            this.Col_Range.Width = 64;
            // 
            // Col_Period
            // 
            this.Col_Period.HeaderText = "Period";
            this.Col_Period.Name = "Col_Period";
            this.Col_Period.ReadOnly = true;
            this.Col_Period.Width = 62;
            // 
            // Col_Header
            // 
            this.Col_Header.HeaderText = "Header";
            this.Col_Header.MaxInputLength = 100;
            this.Col_Header.Name = "Col_Header";
            this.Col_Header.Width = 67;
            // 
            // Col_Calc_Formula
            // 
            this.Col_Calc_Formula.HeaderText = "Calc Formula";
            this.Col_Calc_Formula.Name = "Col_Calc_Formula";
            this.Col_Calc_Formula.Width = 93;
            // 
            // Col_Prec_Source
            // 
            this.Col_Prec_Source.HeaderText = "% Source";
            this.Col_Prec_Source.Name = "Col_Prec_Source";
            this.Col_Prec_Source.Width = 77;
            // 
            // Col_Width
            // 
            dataGridViewCellStyle2.NullValue = "10";
            this.Col_Width.DefaultCellStyle = dataGridViewCellStyle2;
            this.Col_Width.HeaderText = "Width";
            this.Col_Width.Name = "Col_Width";
            this.Col_Width.Width = 60;
            // 
            // Col_Sup
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Col_Sup.DefaultCellStyle = dataGridViewCellStyle3;
            this.Col_Sup.HeaderText = "Sup ?";
            this.Col_Sup.Name = "Col_Sup";
            this.Col_Sup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_Sup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Col_Sup.TrueValue = "";
            this.Col_Sup.Width = 60;
            // 
            // Col_Calc_Divide
            // 
            this.Col_Calc_Divide.HeaderText = "Calc Divide";
            this.Col_Calc_Divide.Name = "Col_Calc_Divide";
            this.Col_Calc_Divide.Width = 86;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Generate_Report_Columns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(906, 408);
            this.ControlBox = false;
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.Lock59);
            this.Controls.Add(this.Lock58);
            this.Controls.Add(this.Lock57);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Generate_Report_Columns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Column Definitions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Generate_Report_Columns_FormClosing);
            this.Load += new System.EventHandler(this.Generate_Report_Columns_Load);
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Lock59.ResumeLayout(false);
            this.Lock58.ResumeLayout(false);
            this.Lock57.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Drawing.Printing.PrintDocument PrintDocument1;
        private System.Windows.Forms.PrintDialog PrintDialog1;
        private System.Windows.Forms.PageSetupDialog PageSetupDialog1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_UserID;
        private System.Windows.Forms.TextBox txtCol_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCol_Code;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.TextBox txtCol_Code;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox Lock59;
        private System.Windows.Forms.GroupBox Lock58;
        private System.Windows.Forms.GroupBox Lock57;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chkactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Header;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Calc_Formula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Prec_Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Width;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Col_Sup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Calc_Divide;

    }
}