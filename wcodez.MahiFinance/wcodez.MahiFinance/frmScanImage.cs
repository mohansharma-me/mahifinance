using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIA;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;

namespace wcodez.MahiFinance
{
    public partial class frmScanImage : Form
    {
        public Image selectedImage = null;
        int cmbCMIndex = 0;
        private Rectangle _selection;
        private bool _selecting = false;

        public frmScanImage()
        {
            InitializeComponent();
        }

        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

        private static void SaveImageToTiff(ImageFile image, string fileName)
        {
            ImageProcess imgProcess = new ImageProcess();
            object convertFilter = "Convert";
            string convertFilterID = imgProcess.FilterInfos.get_Item(ref convertFilter).FilterID;
            imgProcess.Filters.Add(convertFilterID, 0);
            SetWIAProperty(imgProcess.Filters[imgProcess.Filters.Count].Properties, "FormatID", WIA.FormatID.wiaFormatTIFF);
            image = imgProcess.Apply(image);
            image.SaveFile(fileName);
        }

        private static void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel,
                    int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents, int colorMode)
        {
            return;
            string WIA_SCAN_COLOR_MODE = "6146";
            string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            string WIA_SCAN_CONTRAST_PERCENTS = "6155";
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_COLOR_MODE, colorMode);
        }

        private void btnScanNow_Click(object sender, EventArgs e)
        {
            try
            {
                CommonDialogClass commonDialogClass = new CommonDialogClass();
                Device scannerDevice = commonDialogClass.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, false, false);
                if (scannerDevice != null)
                {
                    Item scannnerItem = scannerDevice.Items[1];
                    AdjustScannerSettings(scannnerItem, (int)nudRes.Value, 0, 0, (int)nudWidth.Value, (int)nudHeight.Value, 0, 0, cmbCMIndex);

                    object scanResult = commonDialogClass.ShowTransfer(scannnerItem, WIA.FormatID.wiaFormatTIFF, false);
                    //picScan.Image = (System.Drawing.Image)scanResult;
                    if (scanResult != null)
                    {
                        ImageFile image = (ImageFile)scanResult;

                        try
                        {
                            System.IO.File.Delete("test.tiff");
                        }
                        catch (Exception) { }

                        SaveImageToTiff(image, "test.tiff");

                        pbScan.Image = (Image)Image.FromFile("test.tiff").Clone();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Please check your device connection, device not found." + Environment.NewLine + "Error message:" + err.Message, "Device Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmbColorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCMIndex = cmbColorMode.SelectedIndex;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            selectedImage = pbScan.Image;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selectedImage = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmScanImage_Load(object sender, EventArgs e)
        {
            //pbScan.Image = Image.FromFile("test.tiff");
            //pbScan.ImageLocation = "test.tiff";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        //---------------------------------------------------------------------
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }
        //---------------------------------------------------------------------
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }
        //---------------------------------------------------------------------
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_selecting)
            {
                // Draw a rectangle displaying the current selection
                Pen pen = Pens.GreenYellow;
                e.Graphics.DrawRectangle(pen, _selection);
            }
        }
    }
}
