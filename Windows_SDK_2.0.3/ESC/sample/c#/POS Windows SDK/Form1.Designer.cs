namespace WinFormUSB
{
    partial class Form1
    {
        /// <summary>
        /// necessary designer variables.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean all resource in use.
        /// </summary>
        /// <param name="disposing">Release managed resources? true for yes；false for no</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form designer generator code

        /// <summary>
        /// Default code
        /// Can't be changed.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Printbarcode = new System.Windows.Forms.Button();
            this.Opencashdrawer = new System.Windows.Forms.Button();
            this.button_receipt = new System.Windows.Forms.Button();
            this.button_qr = new System.Windows.Forms.Button();
            this.button_GetStatus = new System.Windows.Forms.Button();
            this.returnvalue = new System.Windows.Forms.TextBox();
            this.buttonOpenCD = new System.Windows.Forms.Button();
            this.CD_Status = new System.Windows.Forms.TextBox();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.FunctionBox = new System.Windows.Forms.GroupBox();
            this.printImage = new System.Windows.Forms.Button();
            this.PortSession = new System.Windows.Forms.GroupBox();
            this.textBoxIPaddress = new System.Windows.Forms.TextBox();
            this.combaudratebox = new System.Windows.Forms.ComboBox();
            this.comportbox = new System.Windows.Forms.ComboBox();
            this.radionet = new System.Windows.Forms.RadioButton();
            this.radiocom = new System.Windows.Forms.RadioButton();
            this.radio_usb = new System.Windows.Forms.RadioButton();
            this.PageMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.FunctionBox.SuspendLayout();
            this.PortSession.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpen.Location = new System.Drawing.Point(6, 241);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(125, 33);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Enabled = false;
            this.buttonClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(161, 241);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(125, 33);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Demo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Printbarcode
            // 
            this.Printbarcode.Enabled = false;
            this.Printbarcode.Location = new System.Drawing.Point(4, 311);
            this.Printbarcode.Name = "Printbarcode";
            this.Printbarcode.Size = new System.Drawing.Size(168, 33);
            this.Printbarcode.TabIndex = 5;
            this.Printbarcode.Text = "Print Barcode";
            this.Printbarcode.UseVisualStyleBackColor = true;
            this.Printbarcode.Click += new System.EventHandler(this.Printbarcode_Click_1);
            // 
            // Opencashdrawer
            // 
            this.Opencashdrawer.Enabled = false;
            this.Opencashdrawer.Location = new System.Drawing.Point(4, 88);
            this.Opencashdrawer.Name = "Opencashdrawer";
            this.Opencashdrawer.Size = new System.Drawing.Size(168, 33);
            this.Opencashdrawer.TabIndex = 6;
            this.Opencashdrawer.Text = "Open CashDrawer";
            this.Opencashdrawer.UseVisualStyleBackColor = true;
            this.Opencashdrawer.Click += new System.EventHandler(this.Opencashdrawer_Click);
            // 
            // button_receipt
            // 
            this.button_receipt.Enabled = false;
            this.button_receipt.Location = new System.Drawing.Point(4, 190);
            this.button_receipt.Name = "button_receipt";
            this.button_receipt.Size = new System.Drawing.Size(168, 33);
            this.button_receipt.TabIndex = 7;
            this.button_receipt.Text = "Print receipt";
            this.button_receipt.UseVisualStyleBackColor = true;
            this.button_receipt.Click += new System.EventHandler(this.button_receipt_Click);
            // 
            // button_qr
            // 
            this.button_qr.Enabled = false;
            this.button_qr.Location = new System.Drawing.Point(4, 248);
            this.button_qr.Name = "button_qr";
            this.button_qr.Size = new System.Drawing.Size(168, 33);
            this.button_qr.TabIndex = 8;
            this.button_qr.Text = "Print QR code";
            this.button_qr.UseVisualStyleBackColor = true;
            this.button_qr.Click += new System.EventHandler(this.button_qr_Click);
            // 
            // button_GetStatus
            // 
            this.button_GetStatus.Enabled = false;
            this.button_GetStatus.Location = new System.Drawing.Point(16, 50);
            this.button_GetStatus.Name = "button_GetStatus";
            this.button_GetStatus.Size = new System.Drawing.Size(168, 33);
            this.button_GetStatus.TabIndex = 9;
            this.button_GetStatus.Text = "Get Status";
            this.button_GetStatus.UseVisualStyleBackColor = true;
            this.button_GetStatus.Click += new System.EventHandler(this.button_GetStatus_Click);
            // 
            // returnvalue
            // 
            this.returnvalue.Location = new System.Drawing.Point(205, 56);
            this.returnvalue.Name = "returnvalue";
            this.returnvalue.ReadOnly = true;
            this.returnvalue.Size = new System.Drawing.Size(196, 25);
            this.returnvalue.TabIndex = 10;
            // 
            // buttonOpenCD
            // 
            this.buttonOpenCD.Enabled = false;
            this.buttonOpenCD.Location = new System.Drawing.Point(4, 140);
            this.buttonOpenCD.Name = "buttonOpenCD";
            this.buttonOpenCD.Size = new System.Drawing.Size(168, 33);
            this.buttonOpenCD.TabIndex = 11;
            this.buttonOpenCD.Text = "Check CashDrawer Status";
            this.buttonOpenCD.UseVisualStyleBackColor = true;
            this.buttonOpenCD.Click += new System.EventHandler(this.buttonCheckCDStatus_Click);
            // 
            // CD_Status
            // 
            this.CD_Status.Location = new System.Drawing.Point(193, 146);
            this.CD_Status.Name = "CD_Status";
            this.CD_Status.ReadOnly = true;
            this.CD_Status.Size = new System.Drawing.Size(196, 25);
            this.CD_Status.TabIndex = 12;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // FunctionBox
            // 
            this.FunctionBox.Controls.Add(this.CD_Status);
            this.FunctionBox.Controls.Add(this.button_receipt);
            this.FunctionBox.Controls.Add(this.buttonOpenCD);
            this.FunctionBox.Controls.Add(this.printImage);
            this.FunctionBox.Controls.Add(this.Printbarcode);
            this.FunctionBox.Controls.Add(this.button_qr);
            this.FunctionBox.Controls.Add(this.Opencashdrawer);
            this.FunctionBox.Location = new System.Drawing.Point(12, 12);
            this.FunctionBox.Name = "FunctionBox";
            this.FunctionBox.Size = new System.Drawing.Size(423, 429);
            this.FunctionBox.TabIndex = 13;
            this.FunctionBox.TabStop = false;
            this.FunctionBox.Text = "Function Area";
            // 
            // printImage
            // 
            this.printImage.Enabled = false;
            this.printImage.Location = new System.Drawing.Point(4, 367);
            this.printImage.Name = "printImage";
            this.printImage.Size = new System.Drawing.Size(168, 33);
            this.printImage.TabIndex = 5;
            this.printImage.Text = "Print Image";
            this.printImage.UseVisualStyleBackColor = true;
            this.printImage.Click += new System.EventHandler(this.printImage_Click);
            // 
            // PortSession
            // 
            this.PortSession.Controls.Add(this.PageMode);
            this.PortSession.Controls.Add(this.textBoxIPaddress);
            this.PortSession.Controls.Add(this.combaudratebox);
            this.PortSession.Controls.Add(this.comportbox);
            this.PortSession.Controls.Add(this.radionet);
            this.PortSession.Controls.Add(this.radiocom);
            this.PortSession.Controls.Add(this.radio_usb);
            this.PortSession.Controls.Add(this.buttonOpen);
            this.PortSession.Controls.Add(this.buttonClose);
            this.PortSession.Location = new System.Drawing.Point(459, 12);
            this.PortSession.Name = "PortSession";
            this.PortSession.Size = new System.Drawing.Size(292, 429);
            this.PortSession.TabIndex = 14;
            this.PortSession.TabStop = false;
            this.PortSession.Text = "Select Port";
            // 
            // textBoxIPaddress
            // 
            this.textBoxIPaddress.Enabled = false;
            this.textBoxIPaddress.Location = new System.Drawing.Point(74, 120);
            this.textBoxIPaddress.Name = "textBoxIPaddress";
            this.textBoxIPaddress.Size = new System.Drawing.Size(206, 25);
            this.textBoxIPaddress.TabIndex = 9;
            // 
            // combaudratebox
            // 
            this.combaudratebox.Enabled = false;
            this.combaudratebox.FormattingEnabled = true;
            this.combaudratebox.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.combaudratebox.Location = new System.Drawing.Point(188, 74);
            this.combaudratebox.Name = "combaudratebox";
            this.combaudratebox.Size = new System.Drawing.Size(92, 25);
            this.combaudratebox.TabIndex = 8;
            // 
            // comportbox
            // 
            this.comportbox.Enabled = false;
            this.comportbox.FormattingEnabled = true;
            this.comportbox.Location = new System.Drawing.Point(74, 74);
            this.comportbox.Name = "comportbox";
            this.comportbox.Size = new System.Drawing.Size(92, 25);
            this.comportbox.TabIndex = 7;
            // 
            // radionet
            // 
            this.radionet.AutoSize = true;
            this.radionet.Location = new System.Drawing.Point(16, 120);
            this.radionet.Name = "radionet";
            this.radionet.Size = new System.Drawing.Size(58, 21);
            this.radionet.TabIndex = 6;
            this.radionet.Text = "NET";
            this.radionet.UseVisualStyleBackColor = true;
            this.radionet.CheckedChanged += new System.EventHandler(this.radionet_CheckedChanged);
            // 
            // radiocom
            // 
            this.radiocom.AutoSize = true;
            this.radiocom.Location = new System.Drawing.Point(16, 77);
            this.radiocom.Name = "radiocom";
            this.radiocom.Size = new System.Drawing.Size(63, 21);
            this.radiocom.TabIndex = 5;
            this.radiocom.Text = "COM";
            this.radiocom.UseVisualStyleBackColor = true;
            this.radiocom.CheckedChanged += new System.EventHandler(this.radiocom_CheckedChanged);
            // 
            // radio_usb
            // 
            this.radio_usb.AutoSize = true;
            this.radio_usb.Checked = true;
            this.radio_usb.Location = new System.Drawing.Point(16, 38);
            this.radio_usb.Name = "radio_usb";
            this.radio_usb.Size = new System.Drawing.Size(59, 21);
            this.radio_usb.TabIndex = 4;
            this.radio_usb.TabStop = true;
            this.radio_usb.Text = "USB";
            this.radio_usb.UseVisualStyleBackColor = true;
            this.radio_usb.CheckedChanged += new System.EventHandler(this.radio_usb_CheckedChanged);
            // 
            // PageMode
            // 
            this.PageMode.Enabled = false;
            this.PageMode.Location = new System.Drawing.Point(59, 336);
            this.PageMode.Name = "PageMode";
            this.PageMode.Size = new System.Drawing.Size(168, 33);
            this.PageMode.TabIndex = 10;
            this.PageMode.Text = "Page Mode";
            this.PageMode.UseVisualStyleBackColor = true;
            this.PageMode.Click += new System.EventHandler(this.PageMode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 479);
            this.Controls.Add(this.returnvalue);
            this.Controls.Add(this.button_GetStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FunctionBox);
            this.Controls.Add(this.PortSession);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS Windows SDK";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.FunctionBox.ResumeLayout(false);
            this.FunctionBox.PerformLayout();
            this.PortSession.ResumeLayout(false);
            this.PortSession.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Printbarcode;
        private System.Windows.Forms.Button Opencashdrawer;
        private System.Windows.Forms.Button button_receipt;
        private System.Windows.Forms.Button button_qr;
        private System.Windows.Forms.Button button_GetStatus;
        private System.Windows.Forms.TextBox returnvalue;
        private System.Windows.Forms.TextBox CD_Status;
        private System.Windows.Forms.Button buttonOpenCD;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.GroupBox FunctionBox;
        private System.Windows.Forms.GroupBox PortSession;
        private System.Windows.Forms.TextBox textBoxIPaddress;
        private System.Windows.Forms.ComboBox combaudratebox;
        private System.Windows.Forms.ComboBox comportbox;
        private System.Windows.Forms.RadioButton radionet;
        private System.Windows.Forms.RadioButton radiocom;
        private System.Windows.Forms.RadioButton radio_usb;
        private System.Windows.Forms.Button printImage;
        private System.Windows.Forms.Button PageMode;
    }
}

