using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPROJECT
{
    public static class csMessageBox
    {
        public static System.Windows.Forms.DialogResult Show(string message, string caption, System.Windows.Forms.MessageBoxButtons button, System.Windows.Forms.MessageBoxIcon icon)           
           
        {
            System.Windows.Forms.DialogResult dlgResult = System.Windows.Forms.DialogResult.None;

            switch (icon)
            {
                case System.Windows.Forms.MessageBoxIcon.Information:
                    using (frmMessageOK msgOK = new frmMessageOK())
                    {
                        msgOK.Text = caption;
                        msgOK.Message = message;

                        dlgResult = msgOK.ShowDialog();
                    }
                    break;


                case System.Windows.Forms.MessageBoxIcon.Question:

                    switch (button)
                    {
                        case System.Windows.Forms.MessageBoxButtons.YesNo:

                            using (frmMessageYesNo msgYesNo = new frmMessageYesNo())
                            {
                                msgYesNo.Text = caption;
                                msgYesNo.Message = message;

                                dlgResult = msgYesNo.ShowDialog();
                            }
                            break;

                        case System.Windows.Forms.MessageBoxButtons.YesNoCancel:

                            using (frmMessageYesNoCancel msgYesNoCancel = new frmMessageYesNoCancel())
                            {
                                msgYesNoCancel.Text = caption;
                                msgYesNoCancel.Message = message;

                                dlgResult = msgYesNoCancel.ShowDialog();
                            }
                            break;
                    }
                    break;

                case System.Windows.Forms.MessageBoxIcon.Warning:
                   using (frmMessageWarning msgWarning = new frmMessageWarning())
                    {
                        msgWarning.Text = caption;
                        msgWarning.Message = message;

                        dlgResult = msgWarning.ShowDialog();
                    }
                    break;
            }
            return dlgResult;

        }
    }
}
