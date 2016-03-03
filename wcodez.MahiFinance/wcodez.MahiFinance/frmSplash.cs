using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace wcodez.MahiFinance
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            loadingCircle1.Active = true;
        }

        private void frmSplash_Shown(object sender, EventArgs e)
        {
            Thread th = new Thread(() => {
                try
                {
                    Thread.Sleep(3000);
                }
                catch (Exception) { }
                finally
                {
                    Action act = () => { Close(); };
                    Invoke(act);
                }
            });
            th.Start();
        }
    }
}
