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
    public partial class frmWait : Form
    {
        public Action Worker { get; set; }
        public frmWait(Action worker, string msg)
        {
            InitializeComponent();
            if (worker == null)
                throw new ArgumentException();
            Worker = worker;
            this.lblMessage.Text = msg;
           
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); },
                TaskScheduler.FromCurrentSynchronizationContext());
        }
        public string Message
        {
            get { return this.lblMessage.Text; }
            set { this.lblMessage.Text = value; }
        }

        
    }
}
