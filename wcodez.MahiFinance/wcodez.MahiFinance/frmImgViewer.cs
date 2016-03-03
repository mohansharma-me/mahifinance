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
    public partial class frmImgViewer : Form
    {
        public frmImgViewer(Image img)
        {
            InitializeComponent();
            this.pictureBox1.Image = img;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "JPEG|*.jpg|All files|*.*";
            if (sd.ShowDialog(this) == DialogResult.OK)
            {
                ((Bitmap)pictureBox1.Image).Save(sd.FileName);
            }
        }
    }
}
