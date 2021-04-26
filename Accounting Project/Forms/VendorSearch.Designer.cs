namespace Accounting_GeneralLedger
{
    partial class VendorSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_VendorCode = new System.Windows.Forms.TextBox();
            this.txt_VendorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_VendorCategory = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.VendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorArabicNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorCheckNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorCityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorCountryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorFaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorTermIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorCreditLimitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorPrintSeparateChecksDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.vendorTaxFileNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorTaxIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorTaxOfficeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propertyCodeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbAccountingProjectDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAccountingProjectDS = new Accounting_GeneralLedger.dbAccountingProjectDS();
            this.btn_NewVendor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendor Code";
            // 
            // txt_VendorCode
            // 
            this.txt_VendorCode.Location = new System.Drawing.Point(231, 6);
            this.txt_VendorCode.Name = "txt_VendorCode";
            this.txt_VendorCode.Size = new System.Drawing.Size(176, 20);
            this.txt_VendorCode.TabIndex = 1;
            this.txt_VendorCode.TextChanged += new System.EventHandler(this.txt_VendorCode_TextChanged);
            // 
            // txt_VendorName
            // 
            this.txt_VendorName.Location = new System.Drawing.Point(231, 32);
            this.txt_VendorName.Name = "txt_VendorName";
            this.txt_VendorName.Size = new System.Drawing.Size(176, 20);
            this.txt_VendorName.TabIndex = 2;
            this.txt_VendorName.TextChanged += new System.EventHandler(this.txt_VendorName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vendor Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vendor Category";
            // 
            // cb_VendorCategory
            // 
            this.cb_VendorCategory.FormattingEnabled = true;
            this.cb_VendorCategory.Location = new System.Drawing.Point(231, 58);
            this.cb_VendorCategory.Name = "cb_VendorCategory";
            this.cb_VendorCategory.Size = new System.Drawing.Size(176, 21);
            this.cb_VendorCategory.TabIndex = 5;
            this.cb_VendorCategory.SelectedIndexChanged += new System.EventHandler(this.cb_VendorCategory_SelectedIndexChanged);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VendorCode,
            this.vendorNameDataGridViewTextBoxColumn,
            this.vendorArabicNameDataGridViewTextBoxColumn,
            this.vendorCheckNameDataGridViewTextBoxColumn,
            this.vendorAddressDataGridViewTextBoxColumn,
            this.vendorCityDataGridViewTextBoxColumn,
            this.vendorCountryDataGridViewTextBoxColumn,
            this.vendorPhoneDataGridViewTextBoxColumn,
            this.vendorFaxDataGridViewTextBoxColumn,
            this.vendorTermIDDataGridViewTextBoxColumn,
            this.vendorStatusDataGridViewTextBoxColumn,
            this.vendorCategoryDataGridViewTextBoxColumn,
            this.vendorCreditLimitDataGridViewTextBoxColumn,
            this.vendorPrintSeparateChecksDataGridViewCheckBoxColumn,
            this.vendorTaxFileNumberDataGridViewTextBoxColumn,
            this.vendorTaxIDDataGridViewTextBoxColumn,
            this.vendorTaxOfficeDataGridViewTextBoxColumn,
            this.propertyCodeIDDataGridViewTextBoxColumn});
            this.dgv.DataMember = "APVendors";
            this.dgv.DataSource = this.dbAccountingProjectDSBindingSource;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 94);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(626, 281);
            this.dgv.TabIndex = 6;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
            // 
            // VendorCode
            // 
            this.VendorCode.DataPropertyName = "VendorCode";
            this.VendorCode.HeaderText = "VendorCode";
            this.VendorCode.Name = "VendorCode";
            this.VendorCode.ReadOnly = true;
            // 
            // vendorNameDataGridViewTextBoxColumn
            // 
            this.vendorNameDataGridViewTextBoxColumn.DataPropertyName = "VendorName";
            this.vendorNameDataGridViewTextBoxColumn.HeaderText = "VendorName";
            this.vendorNameDataGridViewTextBoxColumn.Name = "vendorNameDataGridViewTextBoxColumn";
            this.vendorNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorArabicNameDataGridViewTextBoxColumn
            // 
            this.vendorArabicNameDataGridViewTextBoxColumn.DataPropertyName = "VendorArabicName";
            this.vendorArabicNameDataGridViewTextBoxColumn.HeaderText = "VendorArabicName";
            this.vendorArabicNameDataGridViewTextBoxColumn.Name = "vendorArabicNameDataGridViewTextBoxColumn";
            this.vendorArabicNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorCheckNameDataGridViewTextBoxColumn
            // 
            this.vendorCheckNameDataGridViewTextBoxColumn.DataPropertyName = "VendorCheckName";
            this.vendorCheckNameDataGridViewTextBoxColumn.HeaderText = "VendorCheckName";
            this.vendorCheckNameDataGridViewTextBoxColumn.Name = "vendorCheckNameDataGridViewTextBoxColumn";
            this.vendorCheckNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorAddressDataGridViewTextBoxColumn
            // 
            this.vendorAddressDataGridViewTextBoxColumn.DataPropertyName = "VendorAddress";
            this.vendorAddressDataGridViewTextBoxColumn.HeaderText = "VendorAddress";
            this.vendorAddressDataGridViewTextBoxColumn.Name = "vendorAddressDataGridViewTextBoxColumn";
            this.vendorAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorCityDataGridViewTextBoxColumn
            // 
            this.vendorCityDataGridViewTextBoxColumn.DataPropertyName = "VendorCity";
            this.vendorCityDataGridViewTextBoxColumn.HeaderText = "VendorCity";
            this.vendorCityDataGridViewTextBoxColumn.Name = "vendorCityDataGridViewTextBoxColumn";
            this.vendorCityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorCountryDataGridViewTextBoxColumn
            // 
            this.vendorCountryDataGridViewTextBoxColumn.DataPropertyName = "VendorCountry";
            this.vendorCountryDataGridViewTextBoxColumn.HeaderText = "VendorCountry";
            this.vendorCountryDataGridViewTextBoxColumn.Name = "vendorCountryDataGridViewTextBoxColumn";
            this.vendorCountryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorPhoneDataGridViewTextBoxColumn
            // 
            this.vendorPhoneDataGridViewTextBoxColumn.DataPropertyName = "VendorPhone";
            this.vendorPhoneDataGridViewTextBoxColumn.HeaderText = "VendorPhone";
            this.vendorPhoneDataGridViewTextBoxColumn.Name = "vendorPhoneDataGridViewTextBoxColumn";
            this.vendorPhoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorFaxDataGridViewTextBoxColumn
            // 
            this.vendorFaxDataGridViewTextBoxColumn.DataPropertyName = "VendorFax";
            this.vendorFaxDataGridViewTextBoxColumn.HeaderText = "VendorFax";
            this.vendorFaxDataGridViewTextBoxColumn.Name = "vendorFaxDataGridViewTextBoxColumn";
            this.vendorFaxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorTermIDDataGridViewTextBoxColumn
            // 
            this.vendorTermIDDataGridViewTextBoxColumn.DataPropertyName = "VendorTermID";
            this.vendorTermIDDataGridViewTextBoxColumn.HeaderText = "VendorTermID";
            this.vendorTermIDDataGridViewTextBoxColumn.Name = "vendorTermIDDataGridViewTextBoxColumn";
            this.vendorTermIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorStatusDataGridViewTextBoxColumn
            // 
            this.vendorStatusDataGridViewTextBoxColumn.DataPropertyName = "VendorStatus";
            this.vendorStatusDataGridViewTextBoxColumn.HeaderText = "VendorStatus";
            this.vendorStatusDataGridViewTextBoxColumn.Name = "vendorStatusDataGridViewTextBoxColumn";
            this.vendorStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorCategoryDataGridViewTextBoxColumn
            // 
            this.vendorCategoryDataGridViewTextBoxColumn.DataPropertyName = "VendorCategory";
            this.vendorCategoryDataGridViewTextBoxColumn.HeaderText = "VendorCategory";
            this.vendorCategoryDataGridViewTextBoxColumn.Name = "vendorCategoryDataGridViewTextBoxColumn";
            this.vendorCategoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorCreditLimitDataGridViewTextBoxColumn
            // 
            this.vendorCreditLimitDataGridViewTextBoxColumn.DataPropertyName = "VendorCreditLimit";
            this.vendorCreditLimitDataGridViewTextBoxColumn.HeaderText = "VendorCreditLimit";
            this.vendorCreditLimitDataGridViewTextBoxColumn.Name = "vendorCreditLimitDataGridViewTextBoxColumn";
            this.vendorCreditLimitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorPrintSeparateChecksDataGridViewCheckBoxColumn
            // 
            this.vendorPrintSeparateChecksDataGridViewCheckBoxColumn.DataPropertyName = "VendorPrintSeparateChecks";
            this.vendorPrintSeparateChecksDataGridViewCheckBoxColumn.HeaderText = "VendorPrintSeparateChecks";
            this.vendorPrintSeparateChecksDataGridViewCheckBoxColumn.Name = "vendorPrintSeparateChecksDataGridViewCheckBoxColumn";
            this.vendorPrintSeparateChecksDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // vendorTaxFileNumberDataGridViewTextBoxColumn
            // 
            this.vendorTaxFileNumberDataGridViewTextBoxColumn.DataPropertyName = "VendorTaxFileNumber";
            this.vendorTaxFileNumberDataGridViewTextBoxColumn.HeaderText = "VendorTaxFileNumber";
            this.vendorTaxFileNumberDataGridViewTextBoxColumn.Name = "vendorTaxFileNumberDataGridViewTextBoxColumn";
            this.vendorTaxFileNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorTaxIDDataGridViewTextBoxColumn
            // 
            this.vendorTaxIDDataGridViewTextBoxColumn.DataPropertyName = "VendorTaxID";
            this.vendorTaxIDDataGridViewTextBoxColumn.HeaderText = "VendorTaxID";
            this.vendorTaxIDDataGridViewTextBoxColumn.Name = "vendorTaxIDDataGridViewTextBoxColumn";
            this.vendorTaxIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorTaxOfficeDataGridViewTextBoxColumn
            // 
            this.vendorTaxOfficeDataGridViewTextBoxColumn.DataPropertyName = "VendorTaxOffice";
            this.vendorTaxOfficeDataGridViewTextBoxColumn.HeaderText = "VendorTaxOffice";
            this.vendorTaxOfficeDataGridViewTextBoxColumn.Name = "vendorTaxOfficeDataGridViewTextBoxColumn";
            this.vendorTaxOfficeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // propertyCodeIDDataGridViewTextBoxColumn
            // 
            this.propertyCodeIDDataGridViewTextBoxColumn.DataPropertyName = "PropertyCodeID";
            this.propertyCodeIDDataGridViewTextBoxColumn.HeaderText = "PropertyCodeID";
            this.propertyCodeIDDataGridViewTextBoxColumn.Name = "propertyCodeIDDataGridViewTextBoxColumn";
            this.propertyCodeIDDataGridViewTextBoxColumn.ReadOnly = true;
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
            // btn_NewVendor
            // 
            this.btn_NewVendor.Location = new System.Drawing.Point(495, 66);
            this.btn_NewVendor.Name = "btn_NewVendor";
            this.btn_NewVendor.Size = new System.Drawing.Size(119, 23);
            this.btn_NewVendor.TabIndex = 7;
            this.btn_NewVendor.Text = "Add New Vendor";
            this.btn_NewVendor.UseVisualStyleBackColor = true;
            this.btn_NewVendor.Click += new System.EventHandler(this.btn_NewVendor_Click);
            // 
            // VendorSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(626, 375);
            this.Controls.Add(this.btn_NewVendor);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.cb_VendorCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_VendorName);
            this.Controls.Add(this.txt_VendorCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "VendorSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VendorSearch";
            this.Load += new System.EventHandler(this.VendorSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAccountingProjectDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_VendorCode;
        private System.Windows.Forms.TextBox txt_VendorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_VendorCategory;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.BindingSource dbAccountingProjectDSBindingSource;
        private dbAccountingProjectDS dbAccountingProjectDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorArabicNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorCheckNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorCityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorCountryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorFaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorTermIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorCreditLimitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vendorPrintSeparateChecksDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorTaxFileNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorTaxIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorTaxOfficeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn propertyCodeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btn_NewVendor;
    }
}