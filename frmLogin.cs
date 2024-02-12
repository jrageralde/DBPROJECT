using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
//using MySql.Data;


using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBPROJECT
{
    public partial class frmLogin : Form
    {
        public int loginresult = 0;
        public frmLogin()
        {
            InitializeComponent();
            SetTheme();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public int LoginResult
        {
            get { return this.loginresult; }
            set { this.loginresult = value; }
        }
        public void SetTheme()
        {
            this.BackColor = Globals.gDialogBackgroundColor;

        }
        private void btnShowHide_Click(object sender, EventArgs e)
        {
                 
             if (this.btnShowHide.Text=="Show") {
                this.btnShowHide.Text = "Hide";
                this.btnShowHide.ImageIndex = 1;
                this.txtPassword.PasswordChar = '\0'; 
            } else
            {
                this.btnShowHide.Text = "Show";
                this.btnShowHide.ImageIndex = 0;
                this.txtPassword.PasswordChar = '●';

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (csMessageBox.Show("Exit from this application?", "Please confirm.",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                 this.Hide();
                
            }
            else
            {
                this.txtLoginName.Focus();
                this.DialogResult = DialogResult.None;
            }  
                        
        }

        private void ConnecttoServer()
        {
            if (!Globals.glOpenSqlConn())
            {
                this.Close();
                System.Windows.Forms.Application.Exit();
            }

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            String HashedPwd="",ActualPwd="", pwd = "";

            this.DialogResult = DialogResult.OK;

            if (this.txtLoginName.Text == "")
            {
                csMessageBox.Show("Please provide user name!", "Warning.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       
                this.DialogResult = DialogResult.None;
                this.txtLoginName.Focus();
            }
            else
            {
                 try

                {
                    //Open SqlConnection

                    using (frmWait frm = new frmWait(ConnecttoServer, "Connecting to server:" + Globals.gdbServerName))
                    {
                        frm.ShowDialog(this);

                    }
                    SqlCommand cmd = new SqlCommand("Select id,loginname,password from USERS where LoginName=@LoginName and Active=1", Globals.sqlconn);
                    cmd.Parameters.AddWithValue("@LoginName", this.txtLoginName.Text);

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    adapt.Fill(ds);

                    int count = ds.Tables[0].Rows.Count;

                    if (count == 1)
                                        {
                       pwd = this.txtPassword.Text.Trim();

                       HashedPwd =  ds.Tables[0].Rows[0][2].ToString();
                       ActualPwd = Globals.DecodeFrom64(HashedPwd);

                       // csMessageBox.Show("actual pwd:" + ActualPwd, "Result",
                        //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                       if (pwd == ActualPwd)
                       {
                          Globals.gIdUser =Int32.Parse(ds.Tables[0].Rows[0][0].ToString());

                          Globals.gLoginName = ds.Tables[0].Rows[0][1].ToString();

                          this.DialogResult = DialogResult.OK;
                       }
                       else
                       {
                           csMessageBox.Show("Please provide a valid password.", "Login Failed.",
                              MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                           this.DialogResult = DialogResult.None;
                           this.txtPassword.Focus();
                        }
                    }
                    else
                    {
                       csMessageBox.Show("Please provide a valid login name.", "Login Failed.",
                          MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);

                       this.DialogResult = DialogResult.None;
                       this.txtLoginName.Focus();
                    }

   
                 }  // try

                 catch (Exception ex)
                 {
                    MessageBox.Show(ex.Message);
                 }
            } // else
        } // function

        private void txtLoginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true; // PUT THE DING OFF
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape) this.btnExit.PerformClick();

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin.PerformClick();
                
            } else if (e.KeyCode==Keys.Escape)
            {
                this.btnExit.PerformClick();
            }
        }
    } // class
} // namespace
