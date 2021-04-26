using System;
using Accounting_GeneralLedger.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class frmStrartUp : Form
    {
        public frmStrartUp()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 5;

            if (progressBar1.Value <= 30)
                Pleasewait.Text = "Preparing.....";
            else if (progressBar1.Value <= 50)
                Pleasewait.Text = "Connecting With DataBase.....";
            else if (progressBar1.Value <= 70)
                Pleasewait.Text = "Please wait...";
            else if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                this.Close();
            }
        }

        private void frmStrartUp_Load(object sender, EventArgs e)
        {
            try
            {
                //Version.Text = System.String.Format(Version.Text, Application. ,Application.Info.Version.Minor);
                Version.Text = "Version : " + Application.ProductVersion.ToString();
                Copyright.Text += "  © ABTech 2013 ";
                if (!Conn.MyCon())
                    Application.Exit();

            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}