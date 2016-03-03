namespace wcodez.MahiFinance
{
    partial class frmNewLoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewLoan));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkMortDocument = new System.Windows.Forms.CheckBox();
            this.chkMortGold = new System.Windows.Forms.CheckBox();
            this.chkMortVehicle = new System.Windows.Forms.CheckBox();
            this.chkMortCheck = new System.Windows.Forms.CheckBox();
            this.txtLoanNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbCameras = new System.Windows.Forms.ComboBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.pbCapturedImg = new System.Windows.Forms.PictureBox();
            this.camera = new WebEye.WebCameraControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCustContactNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustFullname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtRefContactNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRefFullname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtDocumentRemarks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGoldRemarks = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVehicleRemarks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCheckRemarks = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAddNext = new System.Windows.Forms.Button();
            this.btnAddPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbScanImage = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapturedImg)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScanImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMortDocument);
            this.groupBox1.Controls.Add(this.chkMortGold);
            this.groupBox1.Controls.Add(this.chkMortVehicle);
            this.groupBox1.Controls.Add(this.chkMortCheck);
            this.groupBox1.Controls.Add(this.txtLoanNumber);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 134);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loan Details";
            // 
            // chkMortDocument
            // 
            this.chkMortDocument.AutoSize = true;
            this.chkMortDocument.Location = new System.Drawing.Point(429, 88);
            this.chkMortDocument.Name = "chkMortDocument";
            this.chkMortDocument.Size = new System.Drawing.Size(116, 22);
            this.chkMortDocument.TabIndex = 9;
            this.chkMortDocument.Text = "Document(s)";
            this.chkMortDocument.UseVisualStyleBackColor = true;
            this.chkMortDocument.CheckedChanged += new System.EventHandler(this.chkMortDocument_CheckedChanged);
            // 
            // chkMortGold
            // 
            this.chkMortGold.AutoSize = true;
            this.chkMortGold.Location = new System.Drawing.Point(341, 88);
            this.chkMortGold.Name = "chkMortGold";
            this.chkMortGold.Size = new System.Drawing.Size(60, 22);
            this.chkMortGold.TabIndex = 8;
            this.chkMortGold.Text = "Gold";
            this.chkMortGold.UseVisualStyleBackColor = true;
            this.chkMortGold.CheckedChanged += new System.EventHandler(this.chkMortGold_CheckedChanged);
            // 
            // chkMortVehicle
            // 
            this.chkMortVehicle.AutoSize = true;
            this.chkMortVehicle.Location = new System.Drawing.Point(240, 88);
            this.chkMortVehicle.Name = "chkMortVehicle";
            this.chkMortVehicle.Size = new System.Drawing.Size(78, 22);
            this.chkMortVehicle.TabIndex = 7;
            this.chkMortVehicle.Text = "Vehicle";
            this.chkMortVehicle.UseVisualStyleBackColor = true;
            this.chkMortVehicle.CheckedChanged += new System.EventHandler(this.chkMortVehicle_CheckedChanged);
            // 
            // chkMortCheck
            // 
            this.chkMortCheck.AutoSize = true;
            this.chkMortCheck.Location = new System.Drawing.Point(147, 88);
            this.chkMortCheck.Name = "chkMortCheck";
            this.chkMortCheck.Size = new System.Drawing.Size(72, 22);
            this.chkMortCheck.TabIndex = 6;
            this.chkMortCheck.Text = "Check";
            this.chkMortCheck.UseVisualStyleBackColor = true;
            this.chkMortCheck.CheckedChanged += new System.EventHandler(this.chkMortCheck_CheckedChanged);
            // 
            // txtLoanNumber
            // 
            this.txtLoanNumber.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanNumber.Location = new System.Drawing.Point(141, 38);
            this.txtLoanNumber.Name = "txtLoanNumber";
            this.txtLoanNumber.Size = new System.Drawing.Size(411, 30);
            this.txtLoanNumber.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mortgage Item :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loan Number : *";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbCameras);
            this.groupBox2.Controls.Add(this.btnCapture);
            this.groupBox2.Controls.Add(this.pbCapturedImg);
            this.groupBox2.Controls.Add(this.camera);
            this.groupBox2.Location = new System.Drawing.Point(618, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 318);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Photo *";
            // 
            // cmbCameras
            // 
            this.cmbCameras.FormattingEnabled = true;
            this.cmbCameras.Location = new System.Drawing.Point(16, 276);
            this.cmbCameras.Name = "cmbCameras";
            this.cmbCameras.Size = new System.Drawing.Size(150, 26);
            this.cmbCameras.TabIndex = 3;
            this.cmbCameras.SelectedIndexChanged += new System.EventHandler(this.cmbCameras_SelectedIndexChanged);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(172, 273);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(37, 31);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "C";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pbCapturedImg
            // 
            this.pbCapturedImg.Location = new System.Drawing.Point(16, 26);
            this.pbCapturedImg.Name = "pbCapturedImg";
            this.pbCapturedImg.Size = new System.Drawing.Size(193, 242);
            this.pbCapturedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCapturedImg.TabIndex = 4;
            this.pbCapturedImg.TabStop = false;
            this.pbCapturedImg.Visible = false;
            this.pbCapturedImg.Click += new System.EventHandler(this.camera_Click);
            // 
            // camera
            // 
            this.camera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.camera.Location = new System.Drawing.Point(16, 26);
            this.camera.Margin = new System.Windows.Forms.Padding(4);
            this.camera.Name = "camera";
            this.camera.Size = new System.Drawing.Size(193, 243);
            this.camera.TabIndex = 2;
            this.camera.Click += new System.EventHandler(this.camera_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCustContactNo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtCustAddress);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtCustFullname);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(598, 165);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customer Details";
            // 
            // txtCustContactNo
            // 
            this.txtCustContactNo.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustContactNo.Location = new System.Drawing.Point(117, 110);
            this.txtCustContactNo.Name = "txtCustContactNo";
            this.txtCustContactNo.Size = new System.Drawing.Size(462, 30);
            this.txtCustContactNo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Contact No : *";
            // 
            // txtCustAddress
            // 
            this.txtCustAddress.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustAddress.Location = new System.Drawing.Point(117, 74);
            this.txtCustAddress.Name = "txtCustAddress";
            this.txtCustAddress.Size = new System.Drawing.Size(462, 30);
            this.txtCustAddress.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Address : *";
            // 
            // txtCustFullname
            // 
            this.txtCustFullname.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustFullname.Location = new System.Drawing.Point(117, 38);
            this.txtCustFullname.Name = "txtCustFullname";
            this.txtCustFullname.Size = new System.Drawing.Size(462, 30);
            this.txtCustFullname.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Full Name : *";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRefContactNo);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtRefFullname);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(12, 183);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(598, 148);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Refference Details";
            // 
            // txtRefContactNo
            // 
            this.txtRefContactNo.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefContactNo.Location = new System.Drawing.Point(117, 74);
            this.txtRefContactNo.Name = "txtRefContactNo";
            this.txtRefContactNo.Size = new System.Drawing.Size(462, 30);
            this.txtRefContactNo.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Contact No :";
            // 
            // txtRefFullname
            // 
            this.txtRefFullname.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefFullname.Location = new System.Drawing.Point(117, 38);
            this.txtRefFullname.Name = "txtRefFullname";
            this.txtRefFullname.Size = new System.Drawing.Size(462, 30);
            this.txtRefFullname.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Full Name :";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtDocumentRemarks);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.txtGoldRemarks);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtVehicleRemarks);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.txtCheckRemarks);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(12, 477);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(829, 146);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Mortgage Remarks";
            // 
            // txtDocumentRemarks
            // 
            this.txtDocumentRemarks.AcceptsReturn = true;
            this.txtDocumentRemarks.Enabled = false;
            this.txtDocumentRemarks.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentRemarks.Location = new System.Drawing.Point(606, 66);
            this.txtDocumentRemarks.Multiline = true;
            this.txtDocumentRemarks.Name = "txtDocumentRemarks";
            this.txtDocumentRemarks.Size = new System.Drawing.Size(209, 60);
            this.txtDocumentRemarks.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(603, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(172, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Document(s) Remarks :";
            // 
            // txtGoldRemarks
            // 
            this.txtGoldRemarks.AcceptsReturn = true;
            this.txtGoldRemarks.Enabled = false;
            this.txtGoldRemarks.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGoldRemarks.Location = new System.Drawing.Point(398, 66);
            this.txtGoldRemarks.Multiline = true;
            this.txtGoldRemarks.Name = "txtGoldRemarks";
            this.txtGoldRemarks.Size = new System.Drawing.Size(200, 60);
            this.txtGoldRemarks.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(395, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Gold Remarks :";
            // 
            // txtVehicleRemarks
            // 
            this.txtVehicleRemarks.AcceptsReturn = true;
            this.txtVehicleRemarks.Enabled = false;
            this.txtVehicleRemarks.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleRemarks.Location = new System.Drawing.Point(207, 66);
            this.txtVehicleRemarks.Multiline = true;
            this.txtVehicleRemarks.Name = "txtVehicleRemarks";
            this.txtVehicleRemarks.Size = new System.Drawing.Size(185, 60);
            this.txtVehicleRemarks.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Vehicle Remarks :";
            // 
            // txtCheckRemarks
            // 
            this.txtCheckRemarks.AcceptsReturn = true;
            this.txtCheckRemarks.Enabled = false;
            this.txtCheckRemarks.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckRemarks.Location = new System.Drawing.Point(28, 66);
            this.txtCheckRemarks.Multiline = true;
            this.txtCheckRemarks.Name = "txtCheckRemarks";
            this.txtCheckRemarks.Size = new System.Drawing.Size(173, 60);
            this.txtCheckRemarks.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Check Remarks :";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 630);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 40);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddNext
            // 
            this.btnAddNext.Location = new System.Drawing.Point(104, 630);
            this.btnAddNext.Name = "btnAddNext";
            this.btnAddNext.Size = new System.Drawing.Size(109, 40);
            this.btnAddNext.TabIndex = 15;
            this.btnAddNext.Text = "&Add Next";
            this.btnAddNext.UseVisualStyleBackColor = true;
            this.btnAddNext.Click += new System.EventHandler(this.btnAddNext_Click);
            // 
            // btnAddPrint
            // 
            this.btnAddPrint.Location = new System.Drawing.Point(219, 630);
            this.btnAddPrint.Name = "btnAddPrint";
            this.btnAddPrint.Size = new System.Drawing.Size(123, 40);
            this.btnAddPrint.TabIndex = 16;
            this.btnAddPrint.Text = "Add && &Print";
            this.btnAddPrint.UseVisualStyleBackColor = true;
            this.btnAddPrint.Click += new System.EventHandler(this.btnAddPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(756, 630);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 40);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbScanImage
            // 
            this.pbScanImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbScanImage.Location = new System.Drawing.Point(588, 348);
            this.pbScanImage.Name = "pbScanImage";
            this.pbScanImage.Size = new System.Drawing.Size(252, 120);
            this.pbScanImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbScanImage.TabIndex = 4;
            this.pbScanImage.TabStop = false;
            this.pbScanImage.Click += new System.EventHandler(this.pbScanImage_Click);
            this.pbScanImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbScanImage_MouseDown);
            // 
            // frmNewLoan
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(853, 682);
            this.Controls.Add(this.btnAddPrint);
            this.Controls.Add(this.btnAddNext);
            this.Controls.Add(this.pbScanImage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewLoan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Loan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNewLoan_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNewLoan_FormClosed);
            this.Load += new System.EventHandler(this.frmNewLoan_Load);
            this.Shown += new System.EventHandler(this.frmNewLoan_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCapturedImg)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScanImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoanNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCustFullname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustContactNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtRefContactNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRefFullname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkMortDocument;
        private System.Windows.Forms.CheckBox chkMortGold;
        private System.Windows.Forms.CheckBox chkMortVehicle;
        private System.Windows.Forms.CheckBox chkMortCheck;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtCheckRemarks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDocumentRemarks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGoldRemarks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVehicleRemarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddNext;
        private System.Windows.Forms.Button btnAddPrint;
        private System.Windows.Forms.Button btnCancel;
        private WebEye.WebCameraControl camera;
        private System.Windows.Forms.ComboBox cmbCameras;
        private System.Windows.Forms.PictureBox pbCapturedImg;
        private System.Windows.Forms.PictureBox pbScanImage;
    }
}

