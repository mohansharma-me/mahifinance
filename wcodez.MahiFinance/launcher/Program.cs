using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using wcodez.MahiFinance;

namespace launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSplash());
            frmMain mainForm = new frmMain(updateMethod);
            Application.Run(mainForm);
        }

        static void updateMethod(IWin32Window owner, String uid, String version)
        {
            new frmUpdate(uid, version).ShowDialog(owner);
        }
    }
}
