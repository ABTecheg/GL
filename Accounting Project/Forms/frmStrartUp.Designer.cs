namespace Accounting_GeneralLedger
{
    partial class frmStrartUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStrartUp));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pleasewait = new System.Windows.Forms.Label();
            this.Copyright = new System.Windows.Forms.Label();
            this.Version = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(297, 249);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(397, 28);
            this.progressBar1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(295, 309);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Pleasewait
            // 
            this.Pleasewait.AutoSize = true;
            this.Pleasewait.BackColor = System.Drawing.Color.Transparent;
            this.Pleasewait.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pleasewait.ForeColor = System.Drawing.Color.LightGray;
            this.Pleasewait.Location = new System.Drawing.Point(306, 283);
            this.Pleasewait.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Pleasewait.Name = "Pleasewait";
            this.Pleasewait.Size = new System.Drawing.Size(173, 23);
            this.Pleasewait.TabIndex = 25;
            this.Pleasewait.Text = "Please wait..........";
            // 
            // Copyright
            // 
            this.Copyright.AutoSize = true;
            this.Copyright.BackColor = System.Drawing.Color.Transparent;
            this.Copyright.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Copyright.ForeColor = System.Drawing.Color.LightGray;
            this.Copyright.Location = new System.Drawing.Point(305, 208);
            this.Copyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Copyright.Name = "Copyright";
            this.Copyright.Size = new System.Drawing.Size(105, 23);
            this.Copyright.TabIndex = 24;
            this.Copyright.Text = "Copyright";
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.BackColor = System.Drawing.Color.Transparent;
            this.Version.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Version.ForeColor = System.Drawing.Color.LightGray;
            this.Version.Location = new System.Drawing.Point(305, 173);
            this.Version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(80, 23);
            this.Version.TabIndex = 23;
            this.Version.Text = "Version";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(307, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(377, 125);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // frmStrartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(696, 311);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Pleasewait);
            this.Controls.Add(this.Copyright);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStrartUp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStrartUp";
            this.Load += new System.EventHandler(this.frmStrartUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label Pleasewait;
        internal System.Windows.Forms.Label Copyright;
        internal System.Windows.Forms.Label Version;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}