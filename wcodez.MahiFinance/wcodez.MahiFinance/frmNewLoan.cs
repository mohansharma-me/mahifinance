using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebEye;

namespace wcodez.MahiFinance
{
    public partial class frmNewLoan : Form
    {
        private bool editMode = false;
        private String editLoanId = "0";
        private Bitmap bmpCapturedImg = null;
        public frmNewLoan()
        {
            InitializeComponent();
        }

        public void setEditMode(String loanid)
        {
            try
            {
                Jobs.Log("NewLoan EditMode " + loanid, null);
                editMode = true;
                editLoanId = loanid;
                Text = "Edit Loan";
                btnAdd.Text = "&Save";
                btnAddNext.Visible = btnAddPrint.Visible = false;
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[setEditMode]", ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmNewLoan_Load(object sender, EventArgs e)
        {

        }

        private void frmNewLoan_Shown(object sender, EventArgs e)
        {
            try
            {
                Jobs.Log("Loading Camera", null);
                cmbCameras.Items.Clear();
                List<WebCameraId> cameras = new List<WebCameraId>(camera.GetVideoCaptureDevices());
                foreach (WebCameraId cam in cameras)
                {
                    cmbCameras.Items.Add(new ComboItem(cam.Name, cam));
                }
                if (cameras.Count > 0)
                {
                    cmbCameras.SelectedIndex = 0;
                }

                if (editMode)
                {
                    Jobs.Log("[EditMode] Filling Loan Details", null);
                    Jobs.fillLoanDetail(this, editLoanId);
                }
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[frmNewLoanShown]", ex);
            }
        }

        public void setValues(String custName, String custAddress, String custCNo, String refname, String refCNo, String loannumber, bool mortCheck, bool mortVehicle, bool mortGold, bool mortDocument, String remarkCheck, String remarkVehicle, String remarkGold, String remarkDocument, Bitmap photo, Bitmap scanPhoto)
        {
            try
            {
                Jobs.Log("NewLoan Setting Values", null);
                txtCustFullname.Text = custName;
                txtCustAddress.Text = custAddress;
                txtCustContactNo.Text = custCNo;
                txtRefFullname.Text = refname;
                txtRefContactNo.Text = refCNo;
                txtLoanNumber.Text = loannumber;
                chkMortCheck.Checked = mortCheck;
                chkMortVehicle.Checked = mortVehicle;
                chkMortGold.Checked = mortGold;
                chkMortDocument.Checked = mortDocument;
                txtCheckRemarks.Text = remarkCheck;
                txtVehicleRemarks.Text = remarkVehicle;
                txtGoldRemarks.Text = remarkGold;
                txtDocumentRemarks.Text = remarkDocument;
                bmpCapturedImg = photo;
                if (bmpCapturedImg != null)
                {
                    camera.Visible = false;
                    pbCapturedImg.Image = Image.FromHbitmap(bmpCapturedImg.GetHbitmap());
                    pbCapturedImg.Visible = true;
                }

                pbScanImage.Image = scanPhoto;
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[SetValues]", ex);
            }
        }

        private void cmbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                if (camera.IsCapturing)
                {
                    Jobs.Log("Camera Capture_Click", null);
                    bmpCapturedImg = camera.GetCurrentImage();
                    camera_Click(sender, e);
                    //bmpCapturedImg.GetThumbnailImage(240, 320, emptyMethod, System.IntPtr.Zero).Save("temp1.bmp");
                }
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[CameraCapture]", ex);
            }
        }

        public bool emptyMethod() { return false; }

        private void camera_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCameras.SelectedIndex >= 0)
                {
                    if (camera.IsCapturing)
                    {
                        camera.StopCapture();
                        if (bmpCapturedImg != null)
                        {
                            camera.Visible = false;
                            pbCapturedImg.Image = Image.FromHbitmap(bmpCapturedImg.GetHbitmap());
                            pbCapturedImg.Visible = true;
                        }
                    }
                    else
                    {
                        if (!camera.Visible)
                        {
                            pbCapturedImg.Visible = false;
                            camera.Visible = true;
                        }
                        camera.StartCapture((WebCameraId)(((ComboItem)cmbCameras.SelectedItem).Value));
                    }
                }
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[CameraClick]", ex);
            }
        }

        private void frmNewLoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmNewLoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (camera.IsCapturing)
                    camera.StopCapture();
                camera.Dispose();
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[NewLoanFormClosing]", ex);
            }
        }

        private void btnAddNext_Click(object sender, EventArgs e)
        {
            addLoan(false);
        }

        private void addLoan(bool close)
        {
            try
            {
                Jobs.Log("NewLoan Add Called", null);
                if (txtCustFullname.Text.Trim().Length == 0)
                {
                    MessageBox.Show(this, "Please enter valid customer's full name.", "Invalid Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCustFullname.Focus();
                    return;
                }
                if (txtCustAddress.Text.Trim().Length == 0)
                {
                    MessageBox.Show(this, "Please enter valid customer's address.", "Invalid Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCustAddress.Focus();
                    return;
                }
                if (txtCustContactNo.Text.Trim().Length == 0)
                {
                    MessageBox.Show(this, "Please enter valid customer's contact number.", "Invalid Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCustContactNo.Focus();
                    return;
                }
                if (txtLoanNumber.Text.Trim().Length == 0)
                {
                    MessageBox.Show(this, "Please enter valid loan number.", "Invalid Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLoanNumber.Focus();
                    return;
                }
                if (bmpCapturedImg == null)
                {
                    if (MessageBox.Show(this, "Are you sure to add loan detail without customer photo ?", "No customer photo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                String separator = Jobs.DATABASE_FIELD_SEPARATOR;
                String mortgageItems = "";
                String mortgageRemarks = "";
                if (chkMortCheck.Checked)
                {
                    mortgageItems = "Check" + separator;
                    mortgageRemarks = txtCheckRemarks.Text + separator;
                }
                else
                {
                    mortgageItems = separator;
                    mortgageRemarks = separator;
                }

                if (chkMortVehicle.Checked)
                {
                    mortgageItems += "Vehicle" + separator;
                    mortgageRemarks += txtVehicleRemarks.Text + separator;
                }
                else
                {
                    mortgageItems += separator;
                    mortgageRemarks += separator;
                }

                if (chkMortGold.Checked)
                {
                    mortgageItems += "Gold" + separator;
                    mortgageRemarks += txtGoldRemarks.Text + separator;
                }
                else
                {
                    mortgageItems += separator;
                    mortgageRemarks += separator;
                }

                if (chkMortDocument.Checked)
                {
                    mortgageItems += "Document";
                    mortgageRemarks += txtDocumentRemarks.Text;
                }
                else
                {
                    mortgageItems += "";
                    mortgageRemarks += "";
                }

                String loanid = null;
                if (editMode)
                    loanid = editLoanId;

                //compress(pbScanImage.Image, "");
                Bitmap bmpCheckScan = null;
                try
                {
                    bmpCheckScan = (Bitmap)pbScanImage.Image; ///Image.FromFile("check1.jpg");
                }
                catch (Exception) { }

                if (Jobs.sqlAddLoan(loanid, txtCustFullname.Text.Trim(), txtCustAddress.Text.Trim(), txtCustContactNo.Text.Trim(), txtRefFullname.Text.Trim(), txtRefContactNo.Text.Trim(), txtLoanNumber.Text.Trim(), mortgageItems, mortgageRemarks, bmpCapturedImg, bmpCheckScan))
                {
                    if (close)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        txtCustFullname.Text = txtCustAddress.Text = txtCustContactNo.Text = txtRefFullname.Text = txtRefContactNo.Text = txtLoanNumber.Text = txtCheckRemarks.Text = txtVehicleRemarks.Text = txtGoldRemarks.Text = txtDocumentRemarks.Text = "";
                        chkMortCheck.Checked = chkMortVehicle.Checked = chkMortGold.Checked = chkMortDocument.Checked = false;
                        bmpCapturedImg = null;
                        if (camera.IsCapturing)
                        {
                            camera.StopCapture();
                        }
                        camera.Visible = true;
                        pbCapturedImg.Visible = false;
                        txtCustFullname.Focus();
                    }
                }
                else
                {
                    MessageBox.Show(this, "Unable to add new loan, please try again." + Environment.NewLine + "Please contact technical team.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[AddLoan]", ex);
            }
        }

        void compress(Image img, string path)
        {
            try
            {
                System.IO.File.Delete("check1.jpg");
            }
            catch (Exception) { }
            EncoderParameter qualityParam =
                new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 60);
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save("check1.jpg", jpegCodec, encoderParams);
        }
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        private void chkMortCheck_CheckedChanged(object sender, EventArgs e)
        {
            txtCheckRemarks.Enabled = chkMortCheck.Checked;
            if (!chkMortCheck.Checked)
                txtCheckRemarks.Text = "";
        }

        private void chkMortVehicle_CheckedChanged(object sender, EventArgs e)
        {
            txtVehicleRemarks.Enabled = chkMortVehicle.Checked;
            if (!chkMortVehicle.Checked)
                txtVehicleRemarks.Text = "";
        }

        private void chkMortGold_CheckedChanged(object sender, EventArgs e)
        {
            txtGoldRemarks.Enabled = chkMortGold.Checked;
            if (!chkMortGold.Checked)
                txtGoldRemarks.Text = "";
        }

        private void chkMortDocument_CheckedChanged(object sender, EventArgs e)
        {
            txtDocumentRemarks.Enabled = chkMortDocument.Checked;
            if (!chkMortDocument.Checked)
                txtDocumentRemarks.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addLoan(true);
        }

        private void btnAddPrint_Click(object sender, EventArgs e)
        {
            String bkLoanNo = txtLoanNumber.Text.Trim();
            addLoan(false);
            frmMain.printLoan(null, bkLoanNo);
            Close();
        }

        private void pbScanImage_Click(object sender, EventArgs e)
        {
            newScanImage();
        }

        private void newScanImage()
        {
            frmScanImage scan= new frmScanImage();
            if (scan.ShowDialog(this)==DialogResult.OK && scan.selectedImage!=null)
            {
                if (pbScanImage.Image != null)
                    pbScanImage.Image.Dispose();
                pbScanImage.Image = scan.selectedImage;
            }
        }

        private void pbScanImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                new frmImgViewer(pbScanImage.Image).ShowDialog(this);
            }
        }
    }
}
