namespace wcodez.MahiFinance
{
    partial class frmScanImage
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
            this.pbScan = new System.Windows.Forms.PictureBox();
            this.btnScanNow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbColorMode = new System.Windows.Forms.ComboBox();
            this.cbxCustomPixel = new System.Windows.Forms.CheckBox();
            this.nudHeightInch = new System.Windows.Forms.NumericUpDown();
            this.nudWidthInch = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRes = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pbScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightInch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthInch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // pbScan
            // 
            this.pbScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbScan.Location = new System.Drawing.Point(12, 12);
            this.pbScan.Name = "pbScan";
            this.pbScan.Size = new System.Drawing.Size(336, 516);
            this.pbScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbScan.TabIndex = 0;
            this.pbScan.TabStop = false;
            this.pbScan.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // btnScanNow
            // 
            this.btnScanNow.Location = new System.Drawing.Point(12, 540);
            this.btnScanNow.Name = "btnScanNow";
            this.btnScanNow.Size = new System.Drawing.Size(84, 36);
            this.btnScanNow.TabIndex = 1;
            this.btnScanNow.Text = "&Scan";
            this.btnScanNow.UseVisualStyleBackColor = true;
            this.btnScanNow.Click += new System.EventHandler(this.btnScanNow_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(264, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(168, 540);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 36);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 18);
            this.label7.TabIndex = 39;
            this.label7.Text = "Color Mode";
            this.label7.Visible = false;
            // 
            // cmbColorMode
            // 
            this.cmbColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorMode.FormattingEnabled = true;
            this.cmbColorMode.Items.AddRange(new object[] {
            "Black and White",
            "Color",
            "Gray Scale"});
            this.cmbColorMode.Location = new System.Drawing.Point(360, 36);
            this.cmbColorMode.Name = "cmbColorMode";
            this.cmbColorMode.Size = new System.Drawing.Size(288, 26);
            this.cmbColorMode.TabIndex = 38;
            this.cmbColorMode.Visible = false;
            this.cmbColorMode.SelectedIndexChanged += new System.EventHandler(this.cmbColorMode_SelectedIndexChanged);
            // 
            // cbxCustomPixel
            // 
            this.cbxCustomPixel.AutoSize = true;
            this.cbxCustomPixel.Location = new System.Drawing.Point(492, 156);
            this.cbxCustomPixel.Name = "cbxCustomPixel";
            this.cbxCustomPixel.Size = new System.Drawing.Size(158, 22);
            this.cbxCustomPixel.TabIndex = 37;
            this.cbxCustomPixel.Text = "Custom Pixel Units";
            this.cbxCustomPixel.UseVisualStyleBackColor = true;
            this.cbxCustomPixel.Visible = false;
            // 
            // nudHeightInch
            // 
            this.nudHeightInch.Location = new System.Drawing.Point(588, 72);
            this.nudHeightInch.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudHeightInch.Name = "nudHeightInch";
            this.nudHeightInch.Size = new System.Drawing.Size(65, 26);
            this.nudHeightInch.TabIndex = 34;
            this.nudHeightInch.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.nudHeightInch.Visible = false;
            // 
            // nudWidthInch
            // 
            this.nudWidthInch.Location = new System.Drawing.Point(456, 72);
            this.nudWidthInch.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.nudWidthInch.Name = "nudWidthInch";
            this.nudWidthInch.Size = new System.Drawing.Size(65, 26);
            this.nudWidthInch.TabIndex = 33;
            this.nudWidthInch.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudWidthInch.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 32;
            this.label2.Text = "Resolution";
            this.label2.Visible = false;
            // 
            // nudRes
            // 
            this.nudRes.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudRes.Location = new System.Drawing.Point(444, 120);
            this.nudRes.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.nudRes.Minimum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.nudRes.Name = "nudRes";
            this.nudRes.Size = new System.Drawing.Size(65, 26);
            this.nudRes.TabIndex = 31;
            this.nudRes.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudRes.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(528, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 30;
            this.label4.Text = "Height";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "Width";
            this.label3.Visible = false;
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(588, 120);
            this.nudHeight.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.ReadOnly = true;
            this.nudHeight.Size = new System.Drawing.Size(65, 26);
            this.nudHeight.TabIndex = 28;
            this.nudHeight.Value = new decimal(new int[] {
            1700,
            0,
            0,
            0});
            this.nudHeight.Visible = false;
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(516, 120);
            this.nudWidth.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.ReadOnly = true;
            this.nudWidth.Size = new System.Drawing.Size(65, 26);
            this.nudWidth.TabIndex = 27;
            this.nudWidth.Value = new decimal(new int[] {
            1250,
            0,
            0,
            0});
            this.nudWidth.Visible = false;
            // 
            // frmScanImage
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(361, 589);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbColorMode);
            this.Controls.Add(this.cbxCustomPixel);
            this.Controls.Add(this.nudHeightInch);
            this.Controls.Add(this.nudWidthInch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudRes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnScanNow);
            this.Controls.Add(this.pbScan);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScanImage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scan Image";
            this.Load += new System.EventHandler(this.frmScanImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightInch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthInch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbScan;
        private System.Windows.Forms.Button btnScanNow;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbColorMode;
        private System.Windows.Forms.CheckBox cbxCustomPixel;
        private System.Windows.Forms.NumericUpDown nudHeightInch;
        private System.Windows.Forms.NumericUpDown nudWidthInch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
    }
}

