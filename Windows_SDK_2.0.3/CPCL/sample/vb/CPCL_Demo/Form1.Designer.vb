<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form


    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    Private components As System.ComponentModel.IContainer


    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_PDF417 = New System.Windows.Forms.Button()
        Me.btn_BitMap = New System.Windows.Forms.Button()
        Me.btn_Bar = New System.Windows.Forms.Button()
        Me.btn_Box = New System.Windows.Forms.Button()
        Me.btn_TextUnderline = New System.Windows.Forms.Button()
        Me.btn_Qrcode = New System.Windows.Forms.Button()
        Me.btn_Barcode = New System.Windows.Forms.Button()
        Me.btn_Text = New System.Windows.Forms.Button()
        Me.tb_Msg = New System.Windows.Forms.TextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.btn_Open = New System.Windows.Forms.Button()
        Me.tb_IP = New System.Windows.Forms.TextBox()
        Me.cb_BaudRate = New System.Windows.Forms.ComboBox()
        Me.cb_COMName = New System.Windows.Forms.ComboBox()
        Me.rb_NET = New System.Windows.Forms.RadioButton()
        Me.rb_COM = New System.Windows.Forms.RadioButton()
        Me.rb_USB = New System.Windows.Forms.RadioButton()
        Me.PrinterStatus = New System.Windows.Forms.Button()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.PrinterStatus)
        Me.groupBox2.Controls.Add(Me.btn_PDF417)
        Me.groupBox2.Controls.Add(Me.btn_BitMap)
        Me.groupBox2.Controls.Add(Me.btn_Bar)
        Me.groupBox2.Controls.Add(Me.btn_Box)
        Me.groupBox2.Controls.Add(Me.btn_TextUnderline)
        Me.groupBox2.Controls.Add(Me.btn_Qrcode)
        Me.groupBox2.Controls.Add(Me.btn_Barcode)
        Me.groupBox2.Controls.Add(Me.btn_Text)
        Me.groupBox2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox2.Location = New System.Drawing.Point(10, 13)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(268, 398)
        Me.groupBox2.TabIndex = 25
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Print"
        '
        'btn_PDF417
        '
        Me.btn_PDF417.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_PDF417.Location = New System.Drawing.Point(129, 172)
        Me.btn_PDF417.Name = "btn_PDF417"
        Me.btn_PDF417.Size = New System.Drawing.Size(118, 30)
        Me.btn_PDF417.TabIndex = 16
        Me.btn_PDF417.Text = "PDF417"
        Me.btn_PDF417.UseVisualStyleBackColor = True
        '
        'btn_BitMap
        '
        Me.btn_BitMap.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_BitMap.Location = New System.Drawing.Point(6, 172)
        Me.btn_BitMap.Name = "btn_BitMap"
        Me.btn_BitMap.Size = New System.Drawing.Size(117, 30)
        Me.btn_BitMap.TabIndex = 13
        Me.btn_BitMap.Text = "BitMap"
        Me.btn_BitMap.UseVisualStyleBackColor = True
        '
        'btn_Bar
        '
        Me.btn_Bar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Bar.Location = New System.Drawing.Point(129, 119)
        Me.btn_Bar.Name = "btn_Bar"
        Me.btn_Bar.Size = New System.Drawing.Size(118, 30)
        Me.btn_Bar.TabIndex = 12
        Me.btn_Bar.Text = "Line"
        Me.btn_Bar.UseVisualStyleBackColor = True
        '
        'btn_Box
        '
        Me.btn_Box.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Box.Location = New System.Drawing.Point(6, 119)
        Me.btn_Box.Name = "btn_Box"
        Me.btn_Box.Size = New System.Drawing.Size(117, 30)
        Me.btn_Box.TabIndex = 11
        Me.btn_Box.Text = "Box"
        Me.btn_Box.UseVisualStyleBackColor = True
        '
        'btn_TextUnderline
        '
        Me.btn_TextUnderline.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_TextUnderline.Location = New System.Drawing.Point(129, 68)
        Me.btn_TextUnderline.Name = "btn_TextUnderline"
        Me.btn_TextUnderline.Size = New System.Drawing.Size(118, 30)
        Me.btn_TextUnderline.TabIndex = 10
        Me.btn_TextUnderline.Text = "TextUnderline"
        Me.btn_TextUnderline.UseVisualStyleBackColor = True
        '
        'btn_Qrcode
        '
        Me.btn_Qrcode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Qrcode.Location = New System.Drawing.Point(6, 68)
        Me.btn_Qrcode.Name = "btn_Qrcode"
        Me.btn_Qrcode.Size = New System.Drawing.Size(117, 30)
        Me.btn_Qrcode.TabIndex = 9
        Me.btn_Qrcode.Text = "Qrcode"
        Me.btn_Qrcode.UseVisualStyleBackColor = True
        '
        'btn_Barcode
        '
        Me.btn_Barcode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Barcode.Location = New System.Drawing.Point(129, 20)
        Me.btn_Barcode.Name = "btn_Barcode"
        Me.btn_Barcode.Size = New System.Drawing.Size(118, 30)
        Me.btn_Barcode.TabIndex = 8
        Me.btn_Barcode.Text = "Barcode"
        Me.btn_Barcode.UseVisualStyleBackColor = True
        '
        'btn_Text
        '
        Me.btn_Text.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Text.Location = New System.Drawing.Point(6, 20)
        Me.btn_Text.Name = "btn_Text"
        Me.btn_Text.Size = New System.Drawing.Size(117, 30)
        Me.btn_Text.TabIndex = 7
        Me.btn_Text.Text = "Text"
        Me.btn_Text.UseVisualStyleBackColor = True
        '
        'tb_Msg
        '
        Me.tb_Msg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_Msg.Location = New System.Drawing.Point(286, 225)
        Me.tb_Msg.Multiline = True
        Me.tb_Msg.Name = "tb_Msg"
        Me.tb_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tb_Msg.Size = New System.Drawing.Size(294, 186)
        Me.tb_Msg.TabIndex = 24
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.btn_Close)
        Me.groupBox1.Controls.Add(Me.btn_Open)
        Me.groupBox1.Controls.Add(Me.tb_IP)
        Me.groupBox1.Controls.Add(Me.cb_BaudRate)
        Me.groupBox1.Controls.Add(Me.cb_COMName)
        Me.groupBox1.Controls.Add(Me.rb_NET)
        Me.groupBox1.Controls.Add(Me.rb_COM)
        Me.groupBox1.Controls.Add(Me.rb_USB)
        Me.groupBox1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(286, 13)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.groupBox1.Size = New System.Drawing.Size(294, 205)
        Me.groupBox1.TabIndex = 23
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Select Port"
        '
        'btn_Close
        '
        Me.btn_Close.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Close.Location = New System.Drawing.Point(165, 154)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(75, 30)
        Me.btn_Close.TabIndex = 6
        Me.btn_Close.Text = "close"
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'btn_Open
        '
        Me.btn_Open.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Open.Location = New System.Drawing.Point(47, 154)
        Me.btn_Open.Name = "btn_Open"
        Me.btn_Open.Size = New System.Drawing.Size(75, 30)
        Me.btn_Open.TabIndex = 6
        Me.btn_Open.Text = "open"
        Me.btn_Open.UseVisualStyleBackColor = True
        '
        'tb_IP
        '
        Me.tb_IP.Enabled = False
        Me.tb_IP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_IP.Location = New System.Drawing.Point(90, 104)
        Me.tb_IP.Name = "tb_IP"
        Me.tb_IP.Size = New System.Drawing.Size(176, 22)
        Me.tb_IP.TabIndex = 5
        '
        'cb_BaudRate
        '
        Me.cb_BaudRate.Enabled = False
        Me.cb_BaudRate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_BaudRate.FormattingEnabled = True
        Me.cb_BaudRate.Items.AddRange(New Object() {"9600", "19200", "38400", "57600", "115200"})
        Me.cb_BaudRate.Location = New System.Drawing.Point(175, 66)
        Me.cb_BaudRate.Name = "cb_BaudRate"
        Me.cb_BaudRate.Size = New System.Drawing.Size(91, 24)
        Me.cb_BaudRate.TabIndex = 4
        '
        'cb_COMName
        '
        Me.cb_COMName.Enabled = False
        Me.cb_COMName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_COMName.FormattingEnabled = True
        Me.cb_COMName.Location = New System.Drawing.Point(90, 66)
        Me.cb_COMName.Name = "cb_COMName"
        Me.cb_COMName.Size = New System.Drawing.Size(68, 24)
        Me.cb_COMName.TabIndex = 3
        '
        'rb_NET
        '
        Me.rb_NET.AutoSize = True
        Me.rb_NET.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_NET.Location = New System.Drawing.Point(24, 105)
        Me.rb_NET.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rb_NET.Name = "rb_NET"
        Me.rb_NET.Size = New System.Drawing.Size(55, 21)
        Me.rb_NET.TabIndex = 2
        Me.rb_NET.Text = "NET"
        Me.rb_NET.UseVisualStyleBackColor = True
        '
        'rb_COM
        '
        Me.rb_COM.AutoSize = True
        Me.rb_COM.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_COM.Location = New System.Drawing.Point(24, 68)
        Me.rb_COM.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rb_COM.Name = "rb_COM"
        Me.rb_COM.Size = New System.Drawing.Size(60, 21)
        Me.rb_COM.TabIndex = 1
        Me.rb_COM.Text = "COM"
        Me.rb_COM.UseVisualStyleBackColor = True
        '
        'rb_USB
        '
        Me.rb_USB.AutoSize = True
        Me.rb_USB.Checked = True
        Me.rb_USB.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_USB.Location = New System.Drawing.Point(24, 34)
        Me.rb_USB.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rb_USB.Name = "rb_USB"
        Me.rb_USB.Size = New System.Drawing.Size(56, 21)
        Me.rb_USB.TabIndex = 0
        Me.rb_USB.TabStop = True
        Me.rb_USB.Text = "USB"
        Me.rb_USB.UseVisualStyleBackColor = True
        '
        'PrinterStatus
        '
        Me.PrinterStatus.Location = New System.Drawing.Point(7, 221)
        Me.PrinterStatus.Name = "PrinterStatus"
        Me.PrinterStatus.Size = New System.Drawing.Size(116, 26)
        Me.PrinterStatus.TabIndex = 17
        Me.PrinterStatus.Text = "PrinterStatus"
        Me.PrinterStatus.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 420)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.tb_Msg)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "Form1"
        Me.Text = "CPCL_Demo"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents groupBox2 As GroupBox
    Private WithEvents btn_PDF417 As Button
    Private WithEvents btn_BitMap As Button
    Private WithEvents btn_Bar As Button
    Private WithEvents btn_Box As Button
    Private WithEvents btn_TextUnderline As Button
    Private WithEvents btn_Qrcode As Button
    Private WithEvents btn_Barcode As Button
    Private WithEvents btn_Text As Button
    Private WithEvents tb_Msg As TextBox
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents btn_Close As Button
    Private WithEvents btn_Open As Button
    Private WithEvents tb_IP As TextBox
    Private WithEvents cb_BaudRate As ComboBox
    Private WithEvents cb_COMName As ComboBox
    Private WithEvents rb_NET As RadioButton
    Private WithEvents rb_COM As RadioButton
    Private WithEvents rb_USB As RadioButton
    Friend WithEvents PrinterStatus As Button
End Class
