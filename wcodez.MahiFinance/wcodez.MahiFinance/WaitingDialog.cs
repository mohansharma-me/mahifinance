using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wcodez.MahiFinance
{
    public partial class WaitingDialog : Form
    {
        private static WaitingDialog wd = null;
        private bool isClosable = false;
        private String title="",message="";
        private bool isProgressManaged = false;

        private WaitingDialog(String title, String message, bool isProgressManaged)
        {
            InitializeComponent();
            this.title = title;
            this.message = message;
            this.isProgressManaged = isProgressManaged;
        }

        public static void showWaitingDialog(IWin32Window form, String title, String message, bool isProgressManaged)
        {
            if (wd == null)
            {
                wd = new WaitingDialog(title, message, isProgressManaged);
            }
            wd.lblTitle.Text = title;
            wd.lblMessage.Text = message;
            wd.isProgressManaged = isProgressManaged;
            if (isProgressManaged)
            {
                wd.pb.Style = ProgressBarStyle.Continuous;
            }
            if (form != null && !wd.Visible)
            {
                wd.ShowDialog(form);
            }
            else
            {
                wd.Show();
            }
        }



        private void WaitingDialog_Load(object sender, EventArgs e)
        {
            Text = lblTitle.Text = title;
            lblMessage.Text = message;
            if (isProgressManaged)
            {
                pb.Style = ProgressBarStyle.Continuous;
            }
            else
            {
                pb.Style = ProgressBarStyle.Marquee;
            }
        }

        public static void closeNow()
        {
            wd.isClosable = true;
            wd.DialogResult = DialogResult.OK;
            wd.Close();
        }

        public static ProgressBar getProgressBar()
        {
            return wd.pb;
        }

        public static Label getTitleLabel() { return wd.lblTitle; }
        public static Label getMessageLabel() { return wd.lblMessage; }

        private void WaitingDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !isClosable;
        }

        private void WaitingDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            wd = null;
        }
    }
}
