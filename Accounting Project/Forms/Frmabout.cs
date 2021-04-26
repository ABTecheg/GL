using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Accounting_GeneralLedger
{
    public partial class Frmabout : Form
    {
        public Frmabout()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frmabout_Load(object sender, EventArgs e)
        {
            if (Function.Lang == "Arabic")
            {
                lbldes.Text = " ’„Ì„ : „Õ„Êœ √”„«⁄Ì·";
                lblmail.Text = " info@advbtech.com : «·»—Ìœ «·√·ﬂ —Ê‰Ï";
                lblStateVer.Text = "√’œ«—«  ﬁ«⁄œ… «·»Ì«‰« ";
                lblphone.Text = " ·Ì›Ê‰ :- 0020224144668";
                lblwebsite.Text = " http://www.advbtech.com/ : «·„Êﬁ⁄ ";
                btnExit.Text = "Exit";
                Function.ApplyRTL(this);
            }
            lblver.Text += Application.ProductVersion.ToString();
            LstVerDB.Items.AddRange(Function.VerDB.ToArray());
        }
        private void lblwebsite_DoubleClick(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblwebsite_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.advbtech.com/");
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblStateVer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (Function.StateVer != "Full Version")
                {
                    if (DialogResult.Yes == MessageBox.Show("Are You Sure You Wont Removing Remaining Days ? \n" + Function.StateVer, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                    {
                        string guid = ((System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), true))[0] as System.Runtime.InteropServices.GuidAttribute).Value.ToString();
                        dllCryptoMT.FrmKey.RemovingDays(guid, "CrYpToMtFoRaHs*2");
                        Function.StateVer = "";
                    }
                }
            }
            catch (Exception ex)
            {
                DataClass.LogError(ex); MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}