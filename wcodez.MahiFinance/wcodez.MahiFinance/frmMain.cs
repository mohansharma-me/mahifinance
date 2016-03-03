using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;
using System.Drawing.Printing;

namespace wcodez.MahiFinance
{
    public partial class frmMain : Form
    {
        public delegate void updateMethod(IWin32Window owner, String uid, String version);
        private updateMethod updater;

        public frmMain(updateMethod um)
        {
            InitializeComponent();
            this.updater = um;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                Jobs.Log("frmMain Shown", null);
                Thread thread = new Thread(new ThreadStart(appStartup));
                thread.Start();
                Jobs.Log("AppStartupThread(Waiting) Started", null);
                WaitingDialog.showWaitingDialog(this, "Starting up...", "", false);
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[frmMainShown]", ex);
            }
        }

        private void appStartup()
        {
            try
            {
                Jobs.Log("appStartup Called", null);
                Action act = null;
                if (!Jobs.isDatabaseExists())
                {
                    act = () => { WaitingDialog.getMessageLabel().Text = "Initiating database..."; };
                    Invoke(act);
                    Jobs.Log("New Database Initilized", null);
                }
                Jobs.initiateDatabaseConnection();
                act = () =>
                {
                    loadLoans();
                };
                Invoke(act);
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[appStartup]", ex);
            }
        }

        

        private void btnNewLoan_Click(object sender, EventArgs e)
        {
            try
            {
                Jobs.Log("NewLoan_Click, Showing NewLoan Form", null);
                new frmNewLoan().ShowDialog(this);
                Jobs.Log("Refreshing Loan List", null);
                loadLoans();
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[NewLoad_Click] ", ex);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void addLoanToLV(ListViewItem li,Image img,String tooltip)
        {
            try
            {
                Action act = () =>
                {
                    //Jobs.Log("AppStartupThread(Waiting) Started", null);
                    if (img != null)
                    {
                        //Jobs.Log("Validating Image Key", null);
                        if (imgsLoans.Images.ContainsKey(li.Tag.ToString()))
                        {
                            //Jobs.Log("Removing Duplicate Image by Key", null);
                            imgsLoans.Images.RemoveByKey(li.Tag.ToString());
                        }
                        imgsLoans.Images.Add(li.Tag.ToString(), img);
                        //Jobs.Log("Image Added in ImageList", null);
                    }
                    else
                    {
                        li.ImageKey = "blank.png";
                        //Jobs.Log("Selecting Blank Image", null);
                    }
                    ListViewItem nli = li.Clone() as ListViewItem;
                    nli.ToolTipText = tooltip;
                    lvLoans.Items.Add(nli);
                    //Jobs.Log("Loan added to LoanList", null);
                };
                Invoke(act);
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[addLoanToLV]", ex);
            }
        }

        private void loadLoans()
        {
            loadLoans("");
        }

        private void loadLoans(String searchFor)
        {
            try
            {
                Jobs.Log("LoadLoans Called", null);
                Thread thLoadLoans = new Thread(new ParameterizedThreadStart(threadLoadLoans));
                thLoadLoans.Name = "Thread: LoadLoans";
                thLoadLoans.Priority = ThreadPriority.Highest;
                thLoadLoans.Start(searchFor);
                Jobs.Log("[loadLoans] Calling Thread", null);
                WaitingDialog.showWaitingDialog(this, "Scanning loans...", "", true);
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[loadLoans]", ex);
            }
        }

        private void threadLoadLoans(object searchFor)
        {
            try
            {
                Action act = () => { lvLoans.Items.Clear(); };
                Invoke(act);
                Jobs.Log("Scanning Loans and Adding in LoanList", null);
                Jobs.scanLoans(addLoanToLV, searchFor.ToString());
                act = () => { WaitingDialog.closeNow(); };
                Invoke(act);
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[threadLoanLoans]", ex);
            }
        }

        private void lvLoans_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lvLoans_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void lvLoans_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //Jobs.Log("Loan_Checked", null);
            if (lvLoans.CheckedItems.Count > 0)
            {
                btnPrint.Enabled = btnDelete.Enabled = true;

            }
            else
            {
                btnPrint.Enabled = btnDelete.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Jobs.Log("DeleteLoan Click", null);
                if (lvLoans.CheckedItems.Count == 0)
                {
                    btnDelete.Enabled = false;
                    return;
                }
                String list = "";
                foreach (ListViewItem li in lvLoans.CheckedItems)
                {
                    list += li.Text + " (" + li.ToolTipText + ")" + Environment.NewLine;
                }
                if (MessageBox.Show(this, "Are you sure to delete following loan entries ?" + Environment.NewLine + list, "Delete Loans", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Jobs.Log("Deleting Selected Loans", null);
                    foreach (ListViewItem li in lvLoans.CheckedItems)
                    {
                        Jobs.deleteLoan(li.Tag.ToString());
                        Jobs.Log('\t' + "Loan Deleted : " + li.ToolTipText, null);
                    }
                    loadLoans();
                }
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[DeleteClick]", ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvLoans.CheckedItems.Count == 0)
                {
                    btnPrint.Enabled = false;
                    return;
                }

                bool printAll = false;
                if (lvLoans.CheckedItems.Count > 1)
                {
                    DialogResult dr = MessageBox.Show(this, "Are you sure to print all checked details ?", "Print All Loans", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        printAll = true;
                    }
                }
                if (lvLoans.CheckedItems.Count==1 || printAll)
                {
                    foreach (ListViewItem li in lvLoans.CheckedItems)
                    {
                        printLoan(li.Tag.ToString(), null);
                    }
                }
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[LoanPrintClick]", ex);
            }
        }

        private static String loanNumber = "";
        private static String custName = "";
        private static String custCNo = "";
        private static String custAddress = "";
        private static String refName = "";
        private static String refCNo = "";
        private static String mgItems = "";
        private static String mgRemarks = "";
        private static Image custPhoto = null, scanPhoto = null;
        private static bool isDetailInited = false;
        private static String rmCheck = "", rmVehicle = "", rmGold = "", rmDocument = "";

        public static bool printLoan(String loanid, String loanno)
        {
            bool ret = false;

            try
            {
                if (loanid == null && loanno == null) { ret = false; return ret; }
                if (loanid == null) loanid = "0";
                if (loanno == null) loanno = "";
                SQLiteParameter[] param = new SQLiteParameter[2];
                param[0] = new SQLiteParameter("@loanid", loanid);
                param[1] = new SQLiteParameter("@loanno", loanno.ToLower().Trim());

                //SQLiteDataReader dr = Jobs.executeReader("select * from loan where " + Jobs.CL_LOANID + "=" + loanid + " or trim(lower(" + Jobs.CL_LOANNO + "))='" + loanno.ToLower().Trim() + "'");
                SQLiteDataReader dr = Jobs.executeReaderWithParam("select * from loan where " + Jobs.CL_LOANID + "=@loanid or trim(lower(" + Jobs.CL_LOANNO + "))=@loanno", param);
                if (dr.Read())
                {
                    loanNumber = dr[Jobs.CL_LOANNO].ToString();
                    custName = dr[Jobs.CL_NAME].ToString();
                    custAddress = dr[Jobs.CL_ADDRESS].ToString();
                    custCNo = dr[Jobs.CL_CONTACTNUMBER].ToString();
                    refName = dr[Jobs.CL_REFNAME].ToString();
                    refCNo = dr[Jobs.CL_REFCONTACTNUMBER].ToString();
                    mgItems = dr[Jobs.CL_MORTGAGE_ITEMS].ToString();
                    mgRemarks = dr[Jobs.CL_MORTGAGE_REMARKS].ToString();

                    String[] rms = mgRemarks.Split(new String[] { Jobs.DATABASE_FIELD_SEPARATOR }, StringSplitOptions.None);
                    if (rms.Length == 4)
                    {
                        rmCheck = rms[0].Trim();
                        rmVehicle = rms[1].Trim();
                        rmGold = rms[2].Trim();
                        rmDocument = rms[3].Trim();
                    }

                    byte[] imgBytes = null;
                    try
                    {
                        imgBytes = (Byte[])dr[Jobs.CL_PHOTO];
                    }
                    catch (Exception)
                    {
                        imgBytes = null;
                    }
                    finally
                    {
                        if (imgBytes != null)
                        {
                            custPhoto = Jobs.ByteToImage(imgBytes);
                        }
                    }

                    byte[] spBytes = null;
                    try
                    {
                        spBytes = (Byte[])dr[Jobs.CL_CHECK_SCAN];
                    }
                    catch (Exception)
                    {
                        spBytes = null;
                    }
                    finally
                    {
                        if (spBytes != null)
                        {
                            scanPhoto = Jobs.ByteToImage(spBytes);
                        }
                    }

                    PrintDialog printDialog = new PrintDialog();
                    using (PrintDocument pDoc = new PrintDocument())
                    {
                        printDialog.Document = pDoc;
                        printDialog.PrinterSettings.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                        pDoc.PrinterSettings = printDialog.PrinterSettings;
                        pDoc.PrintPage += pDoc_PrintPage;
                        if (printDialog.ShowDialog() == DialogResult.OK)
                        {
                            pDoc.Print();
                            ret = true;
                        }
                        if (scanPhoto != null)
                        {
                            pDoc.PrintPage += pDoc_PrintPage1;
                            pDoc.Print();
                        }                        
                    }
                }
                else
                {
                    MessageBox.Show(frmMain.ActiveForm, "Sorry, selected loan details is removed from database.", "Deleted entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[printLoan]", ex);
            }

            loanNumber = custName = custCNo = custAddress = refName = refCNo = mgItems = mgRemarks = rmCheck = rmGold = rmVehicle = rmDocument = "";
            custPhoto = scanPhoto = null;


            return ret;
        }

        static void pDoc_PrintPage1(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            if (scanPhoto != null)
                g.DrawImage(scanPhoto, new RectangleF(0, 0, e.PageBounds.Width, e.PageBounds.Height));
        }

        static void pDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Image imgLogo=(Image)Properties.Resources.PaperLogo;
            Font fntReg = new Font("Arial", 15, FontStyle.Regular);
            Font fntBold = new Font("Arial", 15, FontStyle.Bold);
            SolidBrush brSol=new SolidBrush(Color.Black);
            StringFormat fmtString = new StringFormat();

            g.DrawImage(imgLogo, new RectangleF(0, 0, e.PageBounds.Width, imgLogo.Height-80));

            int y = (imgLogo.Height - 80) + 10;
            fmtString.Alignment = StringAlignment.Far;
            g.DrawString("Reg. no.: " + Jobs.REGISTRATION_NUMBER, fntReg, brSol, e.PageBounds.Width-10, y, fmtString);
            g.DrawString("Loan no.: " + loanNumber, fntReg, brSol, 10, y);

            y+=fntReg.Height+20;
            if (custPhoto != null)
            {
                int pW=240, pH=180;
                int pX = e.PageBounds.Width - pW - 10, pY = y;
                g.DrawImage(custPhoto, new RectangleF(pX, pY, pW, pH));
            }

            int maxWidth = e.PageBounds.Width - 240 - 20;
            int maxWidthInY = (y + 200);

            int x = 10;
            y += 10;

            RectangleF tmpRF=new RectangleF(x, y, maxWidthInY > y ? maxWidth : e.PageBounds.Width - 20, fntReg.Height * 2);

            g.DrawString("Customer Name : ", fntBold, brSol, x, y);
            y += fntBold.Height;

            tmpRF = new RectangleF(x, y, maxWidthInY > y ? maxWidth : e.PageBounds.Width - 20, fntReg.Height * 2);
            g.DrawString(custName, fntReg, brSol, tmpRF);
            y += (int)g.MeasureString(custName, fntReg, tmpRF.Size).Height;
            y += 10;

            g.DrawString("Contact Number : ", fntBold, brSol, x, y);
            y += fntBold.Height;

            tmpRF = new RectangleF(x, y, maxWidthInY > y ? maxWidth : e.PageBounds.Width - 20, fntReg.Height * 1);
            g.DrawString(custCNo, fntReg, brSol, tmpRF);
            y += (int)g.MeasureString(custCNo, fntReg, tmpRF.Size).Height;
            y += 10;

            g.DrawString("Customer Address : ", fntBold, brSol, x, y);
            y += fntBold.Height;

            tmpRF = new RectangleF(x, y, maxWidthInY > y ? maxWidth : e.PageBounds.Width - 20, fntReg.Height * 3);
            g.DrawString(custAddress, fntReg, brSol, tmpRF);
            y += (int)g.MeasureString(custAddress, fntReg, tmpRF.Size).Height;
            y += 10;

            g.DrawString("Refference Name : ", fntBold, brSol, x, y);
            y += fntBold.Height;

            tmpRF = new RectangleF(x, y, maxWidthInY > y ? maxWidth : e.PageBounds.Width - 20, fntReg.Height * 1);
            g.DrawString(refName, fntReg, brSol, tmpRF);
            y += (int)g.MeasureString(refName, fntReg, tmpRF.Size).Height;
            y += 10;

            g.DrawString("Refference Contact : ", fntBold, brSol, x, y);
            y += fntBold.Height;

            tmpRF = new RectangleF(x, y, maxWidthInY > y ? maxWidth : e.PageBounds.Width - 20, fntReg.Height * 1);
            g.DrawString(refCNo, fntReg, brSol, tmpRF);
            y += (int)g.MeasureString(refCNo, fntReg, tmpRF.Size).Height;
            y += 20;

            float col1 = (float)(e.PageBounds.Width * 0.20);
            float col2 = (float)(e.PageBounds.Width * 0.80);

            fntBold = new Font(fntBold, FontStyle.Underline);
            tmpRF = new RectangleF(x, y, col1, fntBold.Height);
            g.DrawString("Mortgage Item", fntBold, brSol, tmpRF);
            tmpRF = new RectangleF(col1, y, col2, fntBold.Height);
            g.DrawString("Remark", fntBold, brSol, tmpRF);
            y += fntBold.Height + 10;
            fntBold = new Font(fntReg, FontStyle.Bold);
            int itemCounter = 1, rmLines = 4;
            fntReg = new Font("Arial", 12, FontStyle.Regular);
            String curStr = "";

            curStr = rmCheck;
            if (curStr.Trim().Length > 0)
            {
                tmpRF = new RectangleF(x, y, col1, fntReg.Height);
                g.DrawString(itemCounter + ". Check", fntReg, brSol, tmpRF);
                tmpRF = new RectangleF(col1, y, col2, fntReg.Height * rmLines);
                g.DrawString(curStr, fntReg, brSol, tmpRF);
                y += (((int)g.MeasureString(curStr, fntReg, tmpRF.Size).Height) + 10);
                itemCounter++;
            }

            curStr = rmVehicle;
            if (curStr.Trim().Length > 0)
            {
                tmpRF = new RectangleF(x, y, col1, fntReg.Height);
                g.DrawString(itemCounter + ". Vehicle", fntReg, brSol, tmpRF);
                tmpRF = new RectangleF(col1, y, col2, fntReg.Height * rmLines);
                g.DrawString(curStr, fntReg, brSol, tmpRF);
                y += (((int)g.MeasureString(curStr, fntReg, tmpRF.Size).Height) + 10);
                itemCounter++;
            }

            curStr = rmGold;
            if (curStr.Trim().Length > 0)
            {
                tmpRF = new RectangleF(x, y, col1, fntReg.Height);
                g.DrawString(itemCounter + ". Gold", fntReg, brSol, tmpRF);
                tmpRF = new RectangleF(col1, y, col2, fntReg.Height * rmLines);
                g.DrawString(curStr, fntReg, brSol, tmpRF);
                y += (((int)g.MeasureString(curStr, fntReg, tmpRF.Size).Height) + 10);
                itemCounter++;
            }

            curStr = rmDocument;
            if (curStr.Trim().Length > 0)
            {
                tmpRF = new RectangleF(x, y, col1, fntReg.Height);
                g.DrawString(itemCounter + ". Document", fntReg, brSol, tmpRF);
                tmpRF = new RectangleF(col1, y, col2, fntReg.Height * rmLines);
                g.DrawString(curStr, fntReg, brSol, tmpRF);
                y += (((int)g.MeasureString(curStr, fntReg, tmpRF.Size).Height) + 10);
                itemCounter++;
            }

            fntReg = new Font("Arial", 12, FontStyle.Regular);

            y = e.PageBounds.Height - (fntReg.Height * 4);
            g.DrawString("Signature", fntReg, brSol, x + 20, y);
            x = e.PageBounds.Width - 30;
            fmtString = new StringFormat();
            fmtString.Alignment = StringAlignment.Far;
            g.DrawString("Proprietary Signature", fntReg, brSol, x, y, fmtString);
        }

        private void lvLoans_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lvLoans.SelectedItems.Count == 1)
                {
                    Jobs.Log("LoanEdit Called", null);
                    frmNewLoan loan = new frmNewLoan();
                    loan.setEditMode(lvLoans.SelectedItems[0].Tag.ToString());
                    loan.ShowDialog(this);
                    loadLoans();
                }
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[LoanListDoubleClick]", ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Jobs.Log("LoanSearch Called", null);
                String searchFor = txtSearch.Text.Trim().ToLower();
                if (searchFor.Length > 2)
                {
                    loadLoans(searchFor);
                }
                else if (searchFor.Length == 0)
                {
                    loadLoans();
                }
            }
            catch (Exception ex)
            {
                Jobs.Log("Error[LoanSearchTB]", ex);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add(new MenuItem("&Check for updates ...", btnSetting_ContextMenu_Action));
            cm.Show(sender as Control, new Point(0,(sender as Control).Height));
        }

        private void btnSetting_ContextMenu_Action(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi.Text.StartsWith("&Check for updates"))
            {
                Jobs.Log("Updater Called", null);
                updater(this, Properties.Resources.uid, Properties.Resources.version);
            }
        }

    }
}
