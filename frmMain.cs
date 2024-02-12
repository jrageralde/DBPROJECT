using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DBPROJECT
{
    public partial class frmMain : Form
    {
        frmLogin fm;   // login form
        public frmMain()
        {
            InitializeComponent();


        }
       
        private void btnExit_Click(object sender, EventArgs e)
        {
            // if (MessageBox.Show("Exit the application?", "Please confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            //         this.Close();
            if (csMessageBox.Show("Exit the application?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            bool mustchangepwd = false;

            Globals.glInitializeVariables();
            this.fm = new frmLogin();

            if (this.fm.ShowDialog() == DialogResult.Abort)
                this.Close();

            if (Globals.gLoginName != null)
            {
                this.txtUserName.Text = Globals.gLoginName;
            }

            if (Globals.gdbServerName != null)
            {
                this.txtServer.Text = Globals.gdbServerName;
            }

            this.glSetSizeToDesktop();
            this.BringToFront();
        }
    }
}
