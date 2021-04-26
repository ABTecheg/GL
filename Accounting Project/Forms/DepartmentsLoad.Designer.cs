
namespace Accounting_GeneralLedger.Forms
{
    partial class DepartmentsLoad
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Choose = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(253, 201);
            this.dataGridView1.TabIndex = 0;
            // 
            // Choose
            // 
            this.Choose.Location = new System.Drawing.Point(161, 238);
            this.Choose.Name = "Choose";
            this.Choose.Size = new System.Drawing.Size(74, 29);
            this.Choose.TabIndex = 1;
            this.Choose.Text = "Choose";
            this.Choose.UseVisualStyleBackColor = true;
            this.Choose.Click += new System.EventHandler(this.Choose_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(36, 238);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(71, 29);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // DepartmentsLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(283, 293);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Choose);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DepartmentsLoad";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DepartmentsLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Choose;
        private System.Windows.Forms.Button Exit;
    }
}