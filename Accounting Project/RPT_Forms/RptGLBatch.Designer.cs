namespace Accounting_GeneralLedger
{
    partial class RptGLBatch
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
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_both = new System.Windows.Forms.RadioButton();
            this.rdb_unpost = new System.Windows.Forms.RadioButton();
            this.rdb_post = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtboxto = new System.Windows.Forms.MaskedTextBox();
            this.txtboxFrom = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkrange = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_from
            // 
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(76, 22);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(98, 20);
            this.dtp_from.TabIndex = 0;
            // 
            // dtp_to
            // 
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to.Location = new System.Drawing.Point(223, 22);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(95, 20);
            this.dtp_to.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_both);
            this.groupBox1.Controls.Add(this.rdb_unpost);
            this.groupBox1.Controls.Add(this.rdb_post);
            this.groupBox1.Location = new System.Drawing.Point(26, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 139);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Status";
            // 
            // rdb_both
            // 
            this.rdb_both.AutoSize = true;
            this.rdb_both.Location = new System.Drawing.Point(28, 101);
            this.rdb_both.Name = "rdb_both";
            this.rdb_both.Size = new System.Drawing.Size(47, 17);
            this.rdb_both.TabIndex = 2;
            this.rdb_both.TabStop = true;
            this.rdb_both.Text = "Both";
            this.rdb_both.UseVisualStyleBackColor = true;
            // 
            // rdb_unpost
            // 
            this.rdb_unpost.AutoSize = true;
            this.rdb_unpost.Location = new System.Drawing.Point(28, 65);
            this.rdb_unpost.Name = "rdb_unpost";
            this.rdb_unpost.Size = new System.Drawing.Size(71, 17);
            this.rdb_unpost.TabIndex = 1;
            this.rdb_unpost.TabStop = true;
            this.rdb_unpost.Text = "UnPosted";
            this.rdb_unpost.UseVisualStyleBackColor = true;
            // 
            // rdb_post
            // 
            this.rdb_post.AutoSize = true;
            this.rdb_post.Location = new System.Drawing.Point(28, 31);
            this.rdb_post.Name = "rdb_post";
            this.rdb_post.Size = new System.Drawing.Size(58, 17);
            this.rdb_post.TabIndex = 0;
            this.rdb_post.TabStop = true;
            this.rdb_post.Text = "Posted";
            this.rdb_post.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtboxto);
            this.groupBox2.Controls.Add(this.txtboxFrom);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.chkrange);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(176, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 139);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Batch Range";
            // 
            // txtboxto
            // 
            this.txtboxto.Location = new System.Drawing.Point(50, 89);
            this.txtboxto.Mask = "000000";
            this.txtboxto.Name = "txtboxto";
            this.txtboxto.Size = new System.Drawing.Size(77, 20);
            this.txtboxto.TabIndex = 27;
            // 
            // txtboxFrom
            // 
            this.txtboxFrom.Location = new System.Drawing.Point(50, 53);
            this.txtboxFrom.Mask = "000000";
            this.txtboxFrom.Name = "txtboxFrom";
            this.txtboxFrom.Size = new System.Drawing.Size(77, 20);
            this.txtboxFrom.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "To";
            // 
            // chkrange
            // 
            this.chkrange.AutoSize = true;
            this.chkrange.Location = new System.Drawing.Point(10, 23);
            this.chkrange.Name = "chkrange";
            this.chkrange.Size = new System.Drawing.Size(127, 17);
            this.chkrange.TabIndex = 22;
            this.chkrange.Text = "Print By Batch Range";
            this.chkrange.UseVisualStyleBackColor = true;
            this.chkrange.CheckedChanged += new System.EventHandler(this.chkrange_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "From";
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = global::Accounting_GeneralLedger.Properties.Resources.font;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(94, 219);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(135, 44);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Show Report";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // RptGLBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 275);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_to);
            this.Controls.Add(this.dtp_from);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RptGLBatch";
            this.Text = "Report G/L Batch";
            this.Load += new System.EventHandler(this.RptGLBatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_both;
        private System.Windows.Forms.RadioButton rdb_unpost;
        private System.Windows.Forms.RadioButton rdb_post;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkrange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtboxto;
        private System.Windows.Forms.MaskedTextBox txtboxFrom;
    }
}