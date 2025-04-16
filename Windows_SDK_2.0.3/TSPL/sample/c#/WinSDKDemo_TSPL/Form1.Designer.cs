namespace WinSDKDemo_TSPL
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Open = new System.Windows.Forms.Button();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.cb_BaudRate = new System.Windows.Forms.ComboBox();
            this.cb_COMName = new System.Windows.Forms.ComboBox();
            this.rb_NET = new System.Windows.Forms.RadioButton();
            this.rb_COM = new System.Windows.Forms.RadioButton();
            this.rb_USB = new System.Windows.Forms.RadioButton();
            this.tb_Msg = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_PDF417 = new System.Windows.Forms.Button();
            this.btn_PrinterStatus = new System.Windows.Forms.Button();
            this.btn_TextBlock = new System.Windows.Forms.Button();
            this.btn_BitMap = new System.Windows.Forms.Button();
            this.btn_Bar = new System.Windows.Forms.Button();
            this.btn_Box = new System.Windows.Forms.Button();
            this.btn_DataMatrix = new System.Windows.Forms.Button();
            this.btn_Qrcode = new System.Windows.Forms.Button();
            this.btn_Barcode = new System.Windows.Forms.Button();
            this.btn_Text = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.btn_Open);
            this.groupBox1.Controls.Add(this.tb_IP);
            this.groupBox1.Controls.Add(this.cb_BaudRate);
            this.groupBox1.Controls.Add(this.cb_COMName);
            this.groupBox1.Controls.Add(this.rb_NET);
            this.groupBox1.Controls.Add(this.rb_COM);
            this.groupBox1.Controls.Add(this.rb_USB);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(288, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(294, 205);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Port";
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(165, 154);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 30);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.Text = "close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Open
            // 
            this.btn_Open.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Open.Location = new System.Drawing.Point(47, 154);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 30);
            this.btn_Open.TabIndex = 6;
            this.btn_Open.Text = "open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // tb_IP
            // 
            this.tb_IP.Enabled = false;
            this.tb_IP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_IP.Location = new System.Drawing.Point(90, 104);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(176, 22);
            this.tb_IP.TabIndex = 5;
            // 
            // cb_BaudRate
            // 
            this.cb_BaudRate.Enabled = false;
            this.cb_BaudRate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_BaudRate.FormattingEnabled = true;
            this.cb_BaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cb_BaudRate.Location = new System.Drawing.Point(175, 66);
            this.cb_BaudRate.Name = "cb_BaudRate";
            this.cb_BaudRate.Size = new System.Drawing.Size(91, 24);
            this.cb_BaudRate.TabIndex = 4;
            // 
            // cb_COMName
            // 
            this.cb_COMName.Enabled = false;
            this.cb_COMName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_COMName.FormattingEnabled = true;
            this.cb_COMName.Location = new System.Drawing.Point(90, 66);
            this.cb_COMName.Name = "cb_COMName";
            this.cb_COMName.Size = new System.Drawing.Size(68, 24);
            this.cb_COMName.TabIndex = 3;
            // 
            // rb_NET
            // 
            this.rb_NET.AutoSize = true;
            this.rb_NET.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_NET.Location = new System.Drawing.Point(24, 105);
            this.rb_NET.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rb_NET.Name = "rb_NET";
            this.rb_NET.Size = new System.Drawing.Size(55, 21);
            this.rb_NET.TabIndex = 2;
            this.rb_NET.Text = "NET";
            this.rb_NET.UseVisualStyleBackColor = true;
            this.rb_NET.CheckedChanged += new System.EventHandler(this.rb_NET_CheckedChanged);
            // 
            // rb_COM
            // 
            this.rb_COM.AutoSize = true;
            this.rb_COM.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_COM.Location = new System.Drawing.Point(24, 68);
            this.rb_COM.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rb_COM.Name = "rb_COM";
            this.rb_COM.Size = new System.Drawing.Size(60, 21);
            this.rb_COM.TabIndex = 1;
            this.rb_COM.Text = "COM";
            this.rb_COM.UseVisualStyleBackColor = true;
            this.rb_COM.CheckedChanged += new System.EventHandler(this.rb_COM_CheckedChanged);
            // 
            // rb_USB
            // 
            this.rb_USB.AutoSize = true;
            this.rb_USB.Checked = true;
            this.rb_USB.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_USB.Location = new System.Drawing.Point(24, 34);
            this.rb_USB.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rb_USB.Name = "rb_USB";
            this.rb_USB.Size = new System.Drawing.Size(56, 21);
            this.rb_USB.TabIndex = 0;
            this.rb_USB.TabStop = true;
            this.rb_USB.Text = "USB";
            this.rb_USB.UseVisualStyleBackColor = true;
            this.rb_USB.CheckedChanged += new System.EventHandler(this.rb_USB_CheckedChanged);
            // 
            // tb_Msg
            // 
            this.tb_Msg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Msg.Location = new System.Drawing.Point(288, 225);
            this.tb_Msg.Multiline = true;
            this.tb_Msg.Name = "tb_Msg";
            this.tb_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Msg.Size = new System.Drawing.Size(294, 186);
            this.tb_Msg.TabIndex = 18;
            this.tb_Msg.TextChanged += new System.EventHandler(this.tb_Msg_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_PDF417);
            this.groupBox2.Controls.Add(this.btn_PrinterStatus);
            this.groupBox2.Controls.Add(this.btn_TextBlock);
            this.groupBox2.Controls.Add(this.btn_BitMap);
            this.groupBox2.Controls.Add(this.btn_Bar);
            this.groupBox2.Controls.Add(this.btn_Box);
            this.groupBox2.Controls.Add(this.btn_DataMatrix);
            this.groupBox2.Controls.Add(this.btn_Qrcode);
            this.groupBox2.Controls.Add(this.btn_Barcode);
            this.groupBox2.Controls.Add(this.btn_Text);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 398);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print";
            // 
            // btn_PDF417
            // 
            this.btn_PDF417.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PDF417.Location = new System.Drawing.Point(129, 175);
            this.btn_PDF417.Name = "btn_PDF417";
            this.btn_PDF417.Size = new System.Drawing.Size(118, 30);
            this.btn_PDF417.TabIndex = 16;
            this.btn_PDF417.Text = "PDF417";
            this.btn_PDF417.UseVisualStyleBackColor = true;
            this.btn_PDF417.Click += new System.EventHandler(this.btn_PDF417_Click);
            // 
            // btn_PrinterStatus
            // 
            this.btn_PrinterStatus.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PrinterStatus.Location = new System.Drawing.Point(6, 222);
            this.btn_PrinterStatus.Name = "btn_PrinterStatus";
            this.btn_PrinterStatus.Size = new System.Drawing.Size(117, 30);
            this.btn_PrinterStatus.TabIndex = 15;
            this.btn_PrinterStatus.Text = "PrinterStatus";
            this.btn_PrinterStatus.UseVisualStyleBackColor = true;
            this.btn_PrinterStatus.Click += new System.EventHandler(this.btn_PrinterStatus_Click);
            // 
            // btn_TextBlock
            // 
            this.btn_TextBlock.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TextBlock.Location = new System.Drawing.Point(129, 222);
            this.btn_TextBlock.Name = "btn_TextBlock";
            this.btn_TextBlock.Size = new System.Drawing.Size(118, 30);
            this.btn_TextBlock.TabIndex = 14;
            this.btn_TextBlock.Text = "TextBlock";
            this.btn_TextBlock.UseVisualStyleBackColor = true;
            this.btn_TextBlock.Click += new System.EventHandler(this.btn_TextBlock_Click);
            // 
            // btn_BitMap
            // 
            this.btn_BitMap.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BitMap.Location = new System.Drawing.Point(6, 172);
            this.btn_BitMap.Name = "btn_BitMap";
            this.btn_BitMap.Size = new System.Drawing.Size(117, 30);
            this.btn_BitMap.TabIndex = 13;
            this.btn_BitMap.Text = "BitMap";
            this.btn_BitMap.UseVisualStyleBackColor = true;
            this.btn_BitMap.Click += new System.EventHandler(this.btn_BitMap_Click);
            // 
            // btn_Bar
            // 
            this.btn_Bar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Bar.Location = new System.Drawing.Point(129, 119);
            this.btn_Bar.Name = "btn_Bar";
            this.btn_Bar.Size = new System.Drawing.Size(118, 30);
            this.btn_Bar.TabIndex = 12;
            this.btn_Bar.Text = "Bar";
            this.btn_Bar.UseVisualStyleBackColor = true;
            this.btn_Bar.Click += new System.EventHandler(this.btn_Bar_Click);
            // 
            // btn_Box
            // 
            this.btn_Box.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Box.Location = new System.Drawing.Point(6, 119);
            this.btn_Box.Name = "btn_Box";
            this.btn_Box.Size = new System.Drawing.Size(117, 30);
            this.btn_Box.TabIndex = 11;
            this.btn_Box.Text = "Box";
            this.btn_Box.UseVisualStyleBackColor = true;
            this.btn_Box.Click += new System.EventHandler(this.btn_Box_Click);
            // 
            // btn_DataMatrix
            // 
            this.btn_DataMatrix.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DataMatrix.Location = new System.Drawing.Point(129, 68);
            this.btn_DataMatrix.Name = "btn_DataMatrix";
            this.btn_DataMatrix.Size = new System.Drawing.Size(118, 30);
            this.btn_DataMatrix.TabIndex = 10;
            this.btn_DataMatrix.Text = "DataMatrix";
            this.btn_DataMatrix.UseVisualStyleBackColor = true;
            this.btn_DataMatrix.Click += new System.EventHandler(this.btn_DataMatrix_Click);
            // 
            // btn_Qrcode
            // 
            this.btn_Qrcode.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Qrcode.Location = new System.Drawing.Point(6, 68);
            this.btn_Qrcode.Name = "btn_Qrcode";
            this.btn_Qrcode.Size = new System.Drawing.Size(117, 30);
            this.btn_Qrcode.TabIndex = 9;
            this.btn_Qrcode.Text = "Qrcode";
            this.btn_Qrcode.UseVisualStyleBackColor = true;
            this.btn_Qrcode.Click += new System.EventHandler(this.btn_Qrcode_Click);
            // 
            // btn_Barcode
            // 
            this.btn_Barcode.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Barcode.Location = new System.Drawing.Point(129, 20);
            this.btn_Barcode.Name = "btn_Barcode";
            this.btn_Barcode.Size = new System.Drawing.Size(118, 30);
            this.btn_Barcode.TabIndex = 8;
            this.btn_Barcode.Text = "Barcode";
            this.btn_Barcode.UseVisualStyleBackColor = true;
            this.btn_Barcode.Click += new System.EventHandler(this.btn_Barcode_Click);
            // 
            // btn_Text
            // 
            this.btn_Text.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Text.Location = new System.Drawing.Point(6, 20);
            this.btn_Text.Name = "btn_Text";
            this.btn_Text.Size = new System.Drawing.Size(117, 30);
            this.btn_Text.TabIndex = 7;
            this.btn_Text.Text = "Text";
            this.btn_Text.UseVisualStyleBackColor = true;
            this.btn_Text.Click += new System.EventHandler(this.btn_Text_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 427);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tb_Msg);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSPL_Demo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.ComboBox cb_BaudRate;
        private System.Windows.Forms.ComboBox cb_COMName;
        private System.Windows.Forms.RadioButton rb_NET;
        private System.Windows.Forms.RadioButton rb_COM;
        private System.Windows.Forms.RadioButton rb_USB;
        private System.Windows.Forms.TextBox tb_Msg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_PDF417;
        private System.Windows.Forms.Button btn_PrinterStatus;
        private System.Windows.Forms.Button btn_TextBlock;
        private System.Windows.Forms.Button btn_BitMap;
        private System.Windows.Forms.Button btn_Bar;
        private System.Windows.Forms.Button btn_Box;
        private System.Windows.Forms.Button btn_DataMatrix;
        private System.Windows.Forms.Button btn_Qrcode;
        private System.Windows.Forms.Button btn_Barcode;
        private System.Windows.Forms.Button btn_Text;
    }
}