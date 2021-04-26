namespace Accounting_GeneralLedger
{
    partial class Generate_Report_Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generate_Report_Setup));
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
            this.txtRpt_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRpt_Code = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.cmbStylePaper = new System.Windows.Forms.ComboBox();
            this.Rpt_Font = new System.Windows.Forms.NumericUpDown();
            this.cmbPaper_Size = new System.Windows.Forms.ComboBox();
            this.lblRpt_Font = new System.Windows.Forms.Label();
            this.lblStylePaper = new System.Windows.Forms.Label();
            this.lblPaper_Size = new System.Windows.Forms.Label();
            this.lblCol_Code = new System.Windows.Forms.Label();
            this.txtCol_Code = new System.Windows.Forms.TextBox();
            this.lblRow_Code = new System.Windows.Forms.Label();
            this.txtRow_Code = new System.Windows.Forms.TextBox();
            this.btnRow_Code = new System.Windows.Forms.Button();
            this.btnCol_Code = new System.Windows.Forms.Button();
            this.chkDaily_Rev = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listAvilableItems = new System.Windows.Forms.ListView();
            this.listChosenItems = new System.Windows.Forms.ListView();
            this.btnalltoAvlItems = new System.Windows.Forms.Button();
            this.btntoAvlItems = new System.Windows.Forms.Button();
            this.btnalltoSelItems = new System.Windows.Forms.Button();
            this.btntoSelItems = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkactive = new System.Windows.Forms.CheckBox();
            this.txtRpt_Code = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.Lock59 = new System.Windows.Forms.GroupBox();
            this.Lock58 = new System.Windows.Forms.GroupBox();
            this.Lock57 = new System.Windows.Forms.GroupBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rpt_Font)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Lock59.SuspendLayout();
            this.Lock58.SuspendLayout();
            this.Lock57.SuspendLayout();
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
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(263, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 72;
            this.label7.Text = "User ID";
            // 
            // txt_UserID
            // 
            this.txt_UserID.BackColor = System.Drawing.Color.White;
            this.txt_UserID.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserID.Location = new System.Drawing.Point(322, 14);
            this.txt_UserID.MaxLength = 30;
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.ReadOnly = true;
            this.txt_UserID.Size = new System.Drawing.Size(103, 22);
            this.txt_UserID.TabIndex = 71;
            // 
            // txtRpt_Name
            // 
            this.txtRpt_Name.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRpt_Name.Location = new System.Drawing.Point(89, 50);
            this.txtRpt_Name.MaxLength = 50;
            this.txtRpt_Name.Name = "txtRpt_Name";
            this.txtRpt_Name.Size = new System.Drawing.Size(261, 22);
            this.txtRpt_Name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // lblRpt_Code
            // 
            this.lblRpt_Code.AutoSize = true;
            this.lblRpt_Code.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRpt_Code.Location = new System.Drawing.Point(45, 18);
            this.lblRpt_Code.Name = "lblRpt_Code";
            this.lblRpt_Code.Size = new System.Drawing.Size(41, 16);
            this.lblRpt_Code.TabIndex = 29;
            this.lblRpt_Code.Text = "Code";
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Image = global::Accounting_GeneralLedger.Properties.Resources.undo;
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndo.Location = new System.Drawing.Point(490, 324);
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
            this.groupDetails.Controls.Add(this.cmbStylePaper);
            this.groupDetails.Controls.Add(this.Rpt_Font);
            this.groupDetails.Controls.Add(this.cmbPaper_Size);
            this.groupDetails.Controls.Add(this.lblRpt_Font);
            this.groupDetails.Controls.Add(this.lblStylePaper);
            this.groupDetails.Controls.Add(this.lblPaper_Size);
            this.groupDetails.Controls.Add(this.lblCol_Code);
            this.groupDetails.Controls.Add(this.txtCol_Code);
            this.groupDetails.Controls.Add(this.lblRow_Code);
            this.groupDetails.Controls.Add(this.txtRow_Code);
            this.groupDetails.Controls.Add(this.btnRow_Code);
            this.groupDetails.Controls.Add(this.btnCol_Code);
            this.groupDetails.Controls.Add(this.chkDaily_Rev);
            this.groupDetails.Controls.Add(this.groupBox3);
            this.groupDetails.Controls.Add(this.chkactive);
            this.groupDetails.Controls.Add(this.lblRpt_Code);
            this.groupDetails.Controls.Add(this.txtRpt_Name);
            this.groupDetails.Controls.Add(this.label7);
            this.groupDetails.Controls.Add(this.label2);
            this.groupDetails.Controls.Add(this.txt_UserID);
            this.groupDetails.Controls.Add(this.txtRpt_Code);
            this.groupDetails.Enabled = false;
            this.groupDetails.Location = new System.Drawing.Point(5, 49);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(707, 265);
            this.groupDetails.TabIndex = 95;
            this.groupDetails.TabStop = false;
            this.groupDetails.EnabledChanged += new System.EventHandler(this.groupDetails_EnabledChanged);
            // 
            // cmbStylePaper
            // 
            this.cmbStylePaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStylePaper.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStylePaper.FormattingEnabled = true;
            this.cmbStylePaper.Items.AddRange(new object[] {
            "Landscape",
            "Portrait"});
            this.cmbStylePaper.Location = new System.Drawing.Point(87, 195);
            this.cmbStylePaper.Name = "cmbStylePaper";
            this.cmbStylePaper.Size = new System.Drawing.Size(121, 24);
            this.cmbStylePaper.TabIndex = 109;
            // 
            // Rpt_Font
            // 
            this.Rpt_Font.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rpt_Font.Location = new System.Drawing.Point(89, 232);
            this.Rpt_Font.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.Rpt_Font.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.Rpt_Font.Name = "Rpt_Font";
            this.Rpt_Font.Size = new System.Drawing.Size(79, 22);
            this.Rpt_Font.TabIndex = 108;
            this.Rpt_Font.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Rpt_Font.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // cmbPaper_Size
            // 
            this.cmbPaper_Size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaper_Size.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaper_Size.FormattingEnabled = true;
            this.cmbPaper_Size.Items.AddRange(new object[] {
            "Excel"});
            this.cmbPaper_Size.Location = new System.Drawing.Point(88, 158);
            this.cmbPaper_Size.Name = "cmbPaper_Size";
            this.cmbPaper_Size.Size = new System.Drawing.Size(121, 24);
            this.cmbPaper_Size.TabIndex = 107;
            // 
            // lblRpt_Font
            // 
            this.lblRpt_Font.AutoSize = true;
            this.lblRpt_Font.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRpt_Font.Location = new System.Drawing.Point(50, 236);
            this.lblRpt_Font.Name = "lblRpt_Font";
            this.lblRpt_Font.Size = new System.Drawing.Size(36, 16);
            this.lblRpt_Font.TabIndex = 106;
            this.lblRpt_Font.Text = "Font";
            // 
            // lblStylePaper
            // 
            this.lblStylePaper.AutoSize = true;
            this.lblStylePaper.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStylePaper.Location = new System.Drawing.Point(8, 199);
            this.lblStylePaper.Name = "lblStylePaper";
            this.lblStylePaper.Size = new System.Drawing.Size(78, 16);
            this.lblStylePaper.TabIndex = 105;
            this.lblStylePaper.Text = "StylePaper";
            // 
            // lblPaper_Size
            // 
            this.lblPaper_Size.AutoSize = true;
            this.lblPaper_Size.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaper_Size.Location = new System.Drawing.Point(5, 162);
            this.lblPaper_Size.Name = "lblPaper_Size";
            this.lblPaper_Size.Size = new System.Drawing.Size(81, 16);
            this.lblPaper_Size.TabIndex = 104;
            this.lblPaper_Size.Text = "Paper_Size";
            // 
            // lblCol_Code
            // 
            this.lblCol_Code.AutoSize = true;
            this.lblCol_Code.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol_Code.Location = new System.Drawing.Point(29, 90);
            this.lblCol_Code.Name = "lblCol_Code";
            this.lblCol_Code.Size = new System.Drawing.Size(57, 16);
            this.lblCol_Code.TabIndex = 102;
            this.lblCol_Code.Text = "Column";
            // 
            // txtCol_Code
            // 
            this.txtCol_Code.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCol_Code.Location = new System.Drawing.Point(89, 86);
            this.txtCol_Code.Name = "txtCol_Code";
            this.txtCol_Code.Size = new System.Drawing.Size(96, 22);
            this.txtCol_Code.TabIndex = 103;
            // 
            // lblRow_Code
            // 
            this.lblRow_Code.AutoSize = true;
            this.lblRow_Code.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRow_Code.Location = new System.Drawing.Point(50, 126);
            this.lblRow_Code.Name = "lblRow_Code";
            this.lblRow_Code.Size = new System.Drawing.Size(36, 16);
            this.lblRow_Code.TabIndex = 100;
            this.lblRow_Code.Text = "Row";
            // 
            // txtRow_Code
            // 
            this.txtRow_Code.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRow_Code.Location = new System.Drawing.Point(89, 122);
            this.txtRow_Code.Name = "txtRow_Code";
            this.txtRow_Code.Size = new System.Drawing.Size(96, 22);
            this.txtRow_Code.TabIndex = 101;
            // 
            // btnRow_Code
            // 
            this.btnRow_Code.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRow_Code.Image = global::Accounting_GeneralLedger.Properties.Resources.find;
            this.btnRow_Code.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRow_Code.Location = new System.Drawing.Point(191, 120);
            this.btnRow_Code.Name = "btnRow_Code";
            this.btnRow_Code.Size = new System.Drawing.Size(47, 25);
            this.btnRow_Code.TabIndex = 99;
            this.btnRow_Code.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRow_Code.UseVisualStyleBackColor = true;
            this.btnRow_Code.Click += new System.EventHandler(this.btnRow_Code_Click);
            // 
            // btnCol_Code
            // 
            this.btnCol_Code.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCol_Code.Image = global::Accounting_GeneralLedger.Properties.Resources.find;
            this.btnCol_Code.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCol_Code.Location = new System.Drawing.Point(191, 84);
            this.btnCol_Code.Name = "btnCol_Code";
            this.btnCol_Code.Size = new System.Drawing.Size(47, 25);
            this.btnCol_Code.TabIndex = 98;
            this.btnCol_Code.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCol_Code.UseVisualStyleBackColor = true;
            this.btnCol_Code.Click += new System.EventHandler(this.btnCol_Code_Click);
            // 
            // chkDaily_Rev
            // 
            this.chkDaily_Rev.AutoSize = true;
            this.chkDaily_Rev.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDaily_Rev.Location = new System.Drawing.Point(497, 15);
            this.chkDaily_Rev.Name = "chkDaily_Rev";
            this.chkDaily_Rev.Size = new System.Drawing.Size(131, 20);
            this.chkDaily_Rev.TabIndex = 97;
            this.chkDaily_Rev.Text = "Daily Revenue ?";
            this.chkDaily_Rev.UseVisualStyleBackColor = true;
            this.chkDaily_Rev.CheckedChanged += new System.EventHandler(this.chkDaily_Rev_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listAvilableItems);
            this.groupBox3.Controls.Add(this.listChosenItems);
            this.groupBox3.Controls.Add(this.btnalltoAvlItems);
            this.groupBox3.Controls.Add(this.btntoAvlItems);
            this.groupBox3.Controls.Add(this.btnalltoSelItems);
            this.groupBox3.Controls.Add(this.btntoSelItems);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(354, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 218);
            this.groupBox3.TabIndex = 96;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "G/L Journals";
            // 
            // listAvilableItems
            // 
            this.listAvilableItems.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listAvilableItems.FullRowSelect = true;
            this.listAvilableItems.HideSelection = false;
            this.listAvilableItems.Location = new System.Drawing.Point(13, 37);
            this.listAvilableItems.Name = "listAvilableItems";
            this.listAvilableItems.Size = new System.Drawing.Size(133, 164);
            this.listAvilableItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listAvilableItems.TabIndex = 532;
            this.listAvilableItems.UseCompatibleStateImageBehavior = false;
            this.listAvilableItems.View = System.Windows.Forms.View.List;
            this.listAvilableItems.DoubleClick += new System.EventHandler(this.listAvilableItems_DoubleClick);
            // 
            // listChosenItems
            // 
            this.listChosenItems.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listChosenItems.FullRowSelect = true;
            this.listChosenItems.HideSelection = false;
            this.listChosenItems.Location = new System.Drawing.Point(194, 37);
            this.listChosenItems.Name = "listChosenItems";
            this.listChosenItems.Size = new System.Drawing.Size(144, 164);
            this.listChosenItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listChosenItems.TabIndex = 531;
            this.listChosenItems.UseCompatibleStateImageBehavior = false;
            this.listChosenItems.View = System.Windows.Forms.View.List;
            this.listChosenItems.DoubleClick += new System.EventHandler(this.listChosenItems_DoubleClick);
            // 
            // btnalltoAvlItems
            // 
            this.btnalltoAvlItems.Image = ((System.Drawing.Image)(resources.GetObject("btnalltoAvlItems.Image")));
            this.btnalltoAvlItems.Location = new System.Drawing.Point(152, 172);
            this.btnalltoAvlItems.Name = "btnalltoAvlItems";
            this.btnalltoAvlItems.Size = new System.Drawing.Size(36, 29);
            this.btnalltoAvlItems.TabIndex = 29;
            this.btnalltoAvlItems.UseVisualStyleBackColor = true;
            this.btnalltoAvlItems.Click += new System.EventHandler(this.btnalltoAvlItems_Click);
            // 
            // btntoAvlItems
            // 
            this.btntoAvlItems.Image = ((System.Drawing.Image)(resources.GetObject("btntoAvlItems.Image")));
            this.btntoAvlItems.Location = new System.Drawing.Point(152, 132);
            this.btntoAvlItems.Name = "btntoAvlItems";
            this.btntoAvlItems.Size = new System.Drawing.Size(36, 29);
            this.btntoAvlItems.TabIndex = 28;
            this.btntoAvlItems.UseVisualStyleBackColor = true;
            this.btntoAvlItems.Click += new System.EventHandler(this.btntoAvlItems_Click);
            // 
            // btnalltoSelItems
            // 
            this.btnalltoSelItems.Image = ((System.Drawing.Image)(resources.GetObject("btnalltoSelItems.Image")));
            this.btnalltoSelItems.Location = new System.Drawing.Point(152, 84);
            this.btnalltoSelItems.Name = "btnalltoSelItems";
            this.btnalltoSelItems.Size = new System.Drawing.Size(36, 29);
            this.btnalltoSelItems.TabIndex = 27;
            this.btnalltoSelItems.UseVisualStyleBackColor = true;
            this.btnalltoSelItems.Click += new System.EventHandler(this.btnalltoSelItems_Click);
            // 
            // btntoSelItems
            // 
            this.btntoSelItems.Image = ((System.Drawing.Image)(resources.GetObject("btntoSelItems.Image")));
            this.btntoSelItems.Location = new System.Drawing.Point(152, 45);
            this.btntoSelItems.Name = "btntoSelItems";
            this.btntoSelItems.Size = new System.Drawing.Size(36, 29);
            this.btntoSelItems.TabIndex = 26;
            this.btntoSelItems.UseVisualStyleBackColor = true;
            this.btntoSelItems.Click += new System.EventHandler(this.btntoSelItems_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Select";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Available";
            // 
            // chkactive
            // 
            this.chkactive.AutoSize = true;
            this.chkactive.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkactive.Location = new System.Drawing.Point(175, 15);
            this.chkactive.Name = "chkactive";
            this.chkactive.Size = new System.Drawing.Size(66, 20);
            this.chkactive.TabIndex = 75;
            this.chkactive.Text = "Active";
            this.chkactive.UseVisualStyleBackColor = true;
            // 
            // txtRpt_Code
            // 
            this.txtRpt_Code.Enabled = false;
            this.txtRpt_Code.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRpt_Code.Location = new System.Drawing.Point(89, 14);
            this.txtRpt_Code.Name = "txtRpt_Code";
            this.txtRpt_Code.Size = new System.Drawing.Size(79, 22);
            this.txtRpt_Code.TabIndex = 30;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(644, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 36);
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
            this.btnExit.Location = new System.Drawing.Point(608, 324);
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
            this.Lock59.Location = new System.Drawing.Point(372, 318);
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
            this.Lock58.Location = new System.Drawing.Point(254, 318);
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
            this.Lock57.Location = new System.Drawing.Point(136, 318);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Generate_Report_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 382);
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
            this.KeyPreview = true;
            this.Name = "Generate_Report_Setup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Definitions";
            this.Load += new System.EventHandler(this.Generate_Report_Setup_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Generate_Report_Setup_FormClosing);
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rpt_Font)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Lock59.ResumeLayout(false);
            this.Lock58.ResumeLayout(false);
            this.Lock57.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtRpt_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRpt_Code;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.TextBox txtRpt_Code;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox Lock59;
        private System.Windows.Forms.GroupBox Lock58;
        private System.Windows.Forms.GroupBox Lock57;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chkactive;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnalltoAvlItems;
        private System.Windows.Forms.Button btntoAvlItems;
        private System.Windows.Forms.Button btnalltoSelItems;
        private System.Windows.Forms.Button btntoSelItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRow_Code;
        private System.Windows.Forms.Button btnCol_Code;
        private System.Windows.Forms.CheckBox chkDaily_Rev;
        private System.Windows.Forms.Label lblRow_Code;
        private System.Windows.Forms.TextBox txtRow_Code;
        private System.Windows.Forms.Label lblCol_Code;
        private System.Windows.Forms.TextBox txtCol_Code;
        private System.Windows.Forms.ComboBox cmbStylePaper;
        private System.Windows.Forms.NumericUpDown Rpt_Font;
        private System.Windows.Forms.ComboBox cmbPaper_Size;
        private System.Windows.Forms.Label lblRpt_Font;
        private System.Windows.Forms.Label lblStylePaper;
        private System.Windows.Forms.Label lblPaper_Size;
        private System.Windows.Forms.ListView listAvilableItems;
        private System.Windows.Forms.ListView listChosenItems;

    }
}