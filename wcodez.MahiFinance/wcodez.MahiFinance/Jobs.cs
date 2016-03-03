using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace wcodez.MahiFinance
{
    class Jobs
    {
        public static SQLiteConnection databaseConnection = null;
        public const int DATABASE_STRUCTURE_VERSION=1;
        public const int DATABASE_VERSION = 3;
        public const String DATABASE_FILE = "database.db";
        public const String DATABASE_FIELD_SEPARATOR = "|--SEP--|";
        public static String REGISTRATION_NUMBER = "GML/3/C/240/20/3";
        
        /* DATABASE COLUMN NAME CONSTANTS */
        public static String CL_LOANID = "loanid";
        public static String CL_LOANNO = "loanno";
        public static String CL_NAME = "name";
        public static String CL_PHOTO = "photo";
        public static String CL_ADDRESS = "address";
        public static String CL_CONTACTNUMBER = "contactnumber";
        public static String CL_REFNAME = "refname";
        public static String CL_REFCONTACTNUMBER = "refcontactnumber";
        public static String CL_MORTGAGE_ITEMS = "mortgage_items";
        public static String CL_MORTGAGE_REMARKS = "mortgage_remarks";
        public static String CL_CHECK_SCAN = "check_scan";

        public static void initiateDatabaseConnection()
        {
            bool flagCreateTables = false;
            if (!isDatabaseExists())
            {
                SQLiteConnection.CreateFile(DATABASE_FILE);
                flagCreateTables = true;
            }
            databaseConnection = new SQLiteConnection("Data Source="+DATABASE_FILE+"; Version="+DATABASE_VERSION+"; New=False; FailIfMissing=True; Synchronous=Full; Compress=True;");
            databaseConnection.Open();
            if (flagCreateTables)
            {
                createTables(DATABASE_STRUCTURE_VERSION);
            }
        }

        private static void createTables(int structureVersion)
        {
            if (structureVersion == 1)
            {
                executeQuery("CREATE TABLE `loan` (`" + CL_LOANID + "` INTEGER NOT NULL,`" + CL_LOANNO + "`	TEXT,`" + CL_NAME + "`	TEXT,`" + CL_ADDRESS + "`	TEXT,`" + CL_CONTACTNUMBER + "`	TEXT,`" + CL_REFNAME + "`	TEXT,`" + CL_REFCONTACTNUMBER + "`	TEXT,`" + CL_MORTGAGE_ITEMS + "`	TEXT,`" + CL_MORTGAGE_REMARKS + "`	TEXT, `" + CL_PHOTO + "` BLOB, `" + CL_CHECK_SCAN + "` BLOB, PRIMARY KEY(" + CL_LOANID + "));");
            }
        }

        public static int executeQuery(String query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, databaseConnection);
            int items = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return items;
        }

        public static SQLiteDataReader executeReader(String query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, databaseConnection);
            return cmd.ExecuteReader();
        }

        public static SQLiteDataReader executeReaderWithParam(String query, SQLiteParameter[] values)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, databaseConnection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteReader();
        }

        public static int executeQueryWithParam(String query,SQLiteParameter[] values)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, databaseConnection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddRange(values);
            int items = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return items;
        }

        public static bool isDatabaseExists()
        {
            return System.IO.File.Exists(DATABASE_FILE);
        }

        public static byte[] BitmapToByte(Bitmap image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public static byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public static Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }

        public static bool sqlAddLoan(String loanid,String custName, String custAddress, String custCNo, String refName, String refCNo, String loanNo, String mortgageItems, String mortgageRemarks, Bitmap photo, Bitmap scanImage)
        {
            SQLiteParameter[] param = new SQLiteParameter[11];
            param[0] = new SQLiteParameter("@photo", photo != null ? ImageToByte(photo.GetThumbnailImage(240, 320, emptyMethod, System.IntPtr.Zero), System.Drawing.Imaging.ImageFormat.Jpeg) : null);
            param[1] = new SQLiteParameter("@custName", custName);
            param[2] = new SQLiteParameter("@custCNo", custCNo);
            param[3] = new SQLiteParameter("@custAddress", custAddress);
            param[4] = new SQLiteParameter("@refName", refName);
            param[5] = new SQLiteParameter("@refCNo", refCNo);
            param[6] = new SQLiteParameter("@loanno", loanNo);
            param[7] = new SQLiteParameter("@loanid", loanid);
            param[8] = new SQLiteParameter("@mgItems", mortgageItems);
            param[9] = new SQLiteParameter("@mgRemarks", mortgageRemarks);
            //.GetThumbnailImage(1200, 480, emptyMethod, System.IntPtr.Zero)
            param[10] = new SQLiteParameter("@checkScan", scanImage != null ? ImageToByte(scanImage, System.Drawing.Imaging.ImageFormat.Jpeg) : null);

            /*if (photo != null)
            {
                param[0].Value = ImageToByte(photo.GetThumbnailImage(240, 320, emptyMethod, System.IntPtr.Zero), System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                param[0].Value = null;
            }*/

            if (loanid == null)
            {
                return executeQueryWithParam("insert into loan(" + CL_NAME + "," + CL_ADDRESS + "," + CL_CONTACTNUMBER + "," + CL_REFNAME + "," + CL_REFCONTACTNUMBER + "," + CL_LOANNO + "," + CL_MORTGAGE_ITEMS + "," + CL_MORTGAGE_REMARKS + "," + CL_PHOTO + "," + CL_CHECK_SCAN + ") values(@custName,@custAddress,@custCNo,@refName,@refCNo,@loanno,@mgItems,@mgRemarks,@photo,@checkScan)", param) > 0;
            }
            else
            {
                return executeQueryWithParam("update loan set " + CL_NAME + "=@custName, " + CL_ADDRESS + "=@custAddress, " + CL_CONTACTNUMBER + "=@custCNo," + CL_REFNAME + "=@refName," + CL_REFCONTACTNUMBER + "=@refCNo," + CL_LOANNO + "=@loanno, " + CL_MORTGAGE_ITEMS + "=@mgItems," + CL_MORTGAGE_REMARKS + "=@mgRemarks," + CL_PHOTO + "=@photo," + CL_CHECK_SCAN + "=@checkScan where " + CL_LOANID + "=@loanid", param) > 0;
            }
        }

        public delegate void addListViewItem(System.Windows.Forms.ListViewItem li,Image img,String tooltip);
        public static bool scanLoans(addListViewItem al, String searchFor)
        {
            String query = "select * from loan";
            if (searchFor.Trim().Length > 2)
            {
                searchFor = searchFor.Trim().ToLower();
                query = "select * from loan where trim(lower(" + CL_LOANNO + ")) LIKE @sf or trim(lower(" + CL_NAME + ")) LIKE @sf or trim(lower(" + CL_ADDRESS + ")) LIKE @sf or trim(lower(" + CL_CONTACTNUMBER + ")) LIKE @sf or trim(lower(" + CL_REFNAME + ")) LIKE @sf or trim(lower(" + CL_REFCONTACTNUMBER + ")) LIKE @sf or trim(lower(" + CL_MORTGAGE_REMARKS + ")) LIKE @sf";
            }

            SQLiteDataReader rd = executeReaderWithParam(query, new SQLiteParameter[] { new SQLiteParameter("@sf", "%"+searchFor+"%") }); //executeReader(query);
            while (rd.Read())
            {
                System.Windows.Forms.ListViewItem li = new System.Windows.Forms.ListViewItem(rd[CL_NAME].ToString(), rd[CL_LOANID].ToString());
                li.Tag = rd[CL_LOANID].ToString();
                String tt = rd[CL_LOANNO].ToString();
                byte[] imgBytes = null;
                bool flag = false;
                try
                {
                    imgBytes = (Byte[])rd[CL_PHOTO];
                    flag = true;
                }
                catch (Exception) { }
                finally
                {
                    if (!flag)
                    {
                        imgBytes = null;
                    }
                }

                li.UseItemStyleForSubItems = true;
                li.Font = new Font(li.Font.FontFamily, 10, FontStyle.Bold);
                if (imgBytes != null && imgBytes.Length > 0)
                {
                    al(li,ByteToImage(imgBytes),tt);
                }
                else
                {
                    al(li,null,tt);
                }
            }
            rd.Close();
            return true;
        }

        public static bool deleteLoan(String loanid)
        {
            return executeQuery("delete from loan where loanid=" + loanid) != 0;
        }

        public static bool emptyMethod() { return false; }

        public static bool fillLoanDetail(frmNewLoan loan, String loanid)
        {
            SQLiteDataReader dr = executeReader("select * from loan where " + CL_LOANID + "=" + loanid);
            if (dr.Read())
            {
                String mortgageItems = dr[CL_MORTGAGE_ITEMS].ToString();
                String mortgageRemarks = dr[CL_MORTGAGE_REMARKS].ToString();
                String[] items = mortgageItems.Split(new String[] { DATABASE_FIELD_SEPARATOR }, StringSplitOptions.None);
                String[] remarks = mortgageRemarks.Split(new String[] { DATABASE_FIELD_SEPARATOR }, StringSplitOptions.None);

                bool mCheck = false, mVehicle = false, mGold = false, mDocument = false;
                String rCheck = "", rVehicle = "", rGold = "", rDocument = "";
                if (items.Length == 4 && remarks.Length == 4) 
                {
                    mCheck = items[0].Trim().Length != 0;
                    rCheck = remarks[0].Trim();

                    mVehicle = items[1].Trim().Length != 0;
                    rVehicle = remarks[1].Trim();

                    mGold = items[2].Trim().Length != 0;
                    rGold = remarks[2].Trim();

                    mDocument = items[3].Trim().Length != 0;
                    rDocument = remarks[3].Trim();
                }

                Image photo = null;
                try
                {
                    photo = ByteToImage((Byte[])dr[CL_PHOTO]);
                }
                catch (Exception) { }

                Image scanPhoto = null;
                try
                {
                    scanPhoto = ByteToImage((Byte[])dr[CL_CHECK_SCAN]);
                }
                catch (Exception) { }

                loan.setValues(dr[CL_NAME].ToString(), dr[CL_ADDRESS].ToString(), dr[CL_CONTACTNUMBER].ToString(), dr[CL_REFNAME].ToString(), dr[CL_REFCONTACTNUMBER].ToString(), dr[CL_LOANNO].ToString(), mCheck, mVehicle, mGold, mDocument, rCheck, rVehicle, rGold, rDocument, (Bitmap)photo, (Bitmap)scanPhoto);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Log(String message, Exception excep)
        {
            try
            {
                Thread thread = new Thread(() => {
                    try
                    {
                        message = Environment.NewLine+DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt <=== ") + message;
                        if (excep != null)
                            message += "[EXCEP: " + excep + " ] ===>";
                        else
                            message += " ===>";
                        File.AppendAllText(Properties.Resources.uid + ".log", message);
                    }
                    catch (Exception) {}
                });
                thread.Start();
            }
            catch (Exception) { }
        }
    }

    public class ComboItem
    {
        public ComboItem(String name, object value)
        {
            this.Name = name;
            this.Value = value;
        }
        public String Name="";
        public object Value = "";

        public override string ToString()
        {
            return Name;
        }

    }

    public static class ImageExtension
    {
        /// <summary>
        /// Crops an image according to a selection rectangel
        /// </summary>
        /// <param name="image">
        /// the image to be cropped
        /// </param>
        /// <param name="selection">
        /// the selection
        /// </param>
        /// <returns>
        /// cropped image
        /// </returns>
        public static Image Crop(this Image image, Rectangle selection)
        {
            Bitmap bmp = image as Bitmap;

            // Check if it is a bitmap:
            if (bmp == null)
                throw new ArgumentException("Kein gültiges Bild (Bitmap)");

            

            // Crop the image:
            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

            // Release the resources:
            image.Dispose();

            return cropBmp;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Fits an image to the size of a picturebox
        /// </summary>
        /// <param name="image">
        /// image to be fit
        /// </param>
        /// <param name="picBox">
        /// picturebox in that the image should fit
        /// </param>
        /// <returns>
        /// fitted image
        /// </returns>
        /// <remarks>
        /// Although the picturebox has the SizeMode-property that offers
        /// the same functionality an OutOfMemory-Exception is thrown
        /// when assigning images to a picturebox several times.
        /// 
        /// AFAIK the SizeMode is designed for assigning an image to
        /// picturebox only once.
        /// </remarks>
        public static Image Fit2PictureBox(this Image image, System.Windows.Forms.PictureBox picBox)
        {
            Bitmap bmp = null;
            Graphics g;

            // Scale:
            double scaleY = (double)image.Width / picBox.Width;
            double scaleX = (double)image.Height / picBox.Height;
            double scale = scaleY < scaleX ? scaleX : scaleY;

            // Create new bitmap:
            bmp = new Bitmap(
                (int)((double)image.Width / scale),
                (int)((double)image.Height / scale));

            // Set resolution of the new image:
            bmp.SetResolution(
                image.HorizontalResolution,
                image.VerticalResolution);

            // Create graphics:
            g = Graphics.FromImage(bmp);

            // Set interpolation mode:
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Draw the new image:
            g.DrawImage(
                image,
                new Rectangle(			// Ziel
                    0, 0,
                    bmp.Width, bmp.Height),
                new Rectangle(			// Quelle
                    0, 0,
                    image.Width, image.Height),
                GraphicsUnit.Pixel);

            // Release the resources of the graphics:
            g.Dispose();

            // Release the resources of the origin image:
            image.Dispose();

            return bmp;
        }
    }
}
