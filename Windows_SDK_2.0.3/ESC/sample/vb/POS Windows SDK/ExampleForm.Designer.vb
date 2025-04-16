<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExampleForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExampleForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxCashDrawerStatus = New System.Windows.Forms.TextBox()
        Me.printImageBtn = New System.Windows.Forms.Button()
        Me.ButtonPrintBarcode = New System.Windows.Forms.Button()
        Me.TextBoxPrinterStatus = New System.Windows.Forms.TextBox()
        Me.ButtonPrintQrcode = New System.Windows.Forms.Button()
        Me.ButtonPrintReceipt = New System.Windows.Forms.Button()
        Me.ButtonCheckCashDrawerStatus = New System.Windows.Forms.Button()
        Me.ButtonOpenCashDrawer = New System.Windows.Forms.Button()
        Me.ButtonGetPrinterStatus = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.ButtonOpen = New System.Windows.Forms.Button()
        Me.ComboBoxBaudrate = New System.Windows.Forms.ComboBox()
        Me.ComboBoxPortName = New System.Windows.Forms.ComboBox()
        Me.TextBoxHost = New System.Windows.Forms.TextBox()
        Me.RadioButtonNet = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCom = New System.Windows.Forms.RadioButton()
        Me.RadioButtonUsb = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxCashDrawerStatus)
        Me.GroupBox1.Controls.Add(Me.printImageBtn)
        Me.GroupBox1.Controls.Add(Me.ButtonPrintBarcode)
        Me.GroupBox1.Controls.Add(Me.TextBoxPrinterStatus)
        Me.GroupBox1.Controls.Add(Me.ButtonPrintQrcode)
        Me.GroupBox1.Controls.Add(Me.ButtonPrintReceipt)
        Me.GroupBox1.Controls.Add(Me.ButtonCheckCashDrawerStatus)
        Me.GroupBox1.Controls.Add(Me.ButtonOpenCashDrawer)
        Me.GroupBox1.Controls.Add(Me.ButtonGetPrinterStatus)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(349, 289)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Function Area"
        '
        'TextBoxCashDrawerStatus
        '
        Me.TextBoxCashDrawerStatus.Location = New System.Drawing.Point(163, 100)
        Me.TextBoxCashDrawerStatus.Name = "TextBoxCashDrawerStatus"
        Me.TextBoxCashDrawerStatus.Size = New System.Drawing.Size(164, 21)
        Me.TextBoxCashDrawerStatus.TabIndex = 7
        '
        'printImage
        '
        Me.printImageBtn.Location = New System.Drawing.Point(12, 254)
        Me.printImageBtn.Name = "printImage"
        Me.printImageBtn.Size = New System.Drawing.Size(131, 23)
        Me.printImageBtn.TabIndex = 6
        Me.printImageBtn.Text = "Print Image"
        Me.printImageBtn.UseVisualStyleBackColor = True
        '
        'ButtonPrintBarcode
        '
        Me.ButtonPrintBarcode.Location = New System.Drawing.Point(13, 217)
        Me.ButtonPrintBarcode.Name = "ButtonPrintBarcode"
        Me.ButtonPrintBarcode.Size = New System.Drawing.Size(131, 23)
        Me.ButtonPrintBarcode.TabIndex = 6
        Me.ButtonPrintBarcode.Text = "Print Barcode"
        Me.ButtonPrintBarcode.UseVisualStyleBackColor = True
        '
        'TextBoxPrinterStatus
        '
        Me.TextBoxPrinterStatus.Location = New System.Drawing.Point(163, 20)
        Me.TextBoxPrinterStatus.Name = "TextBoxPrinterStatus"
        Me.TextBoxPrinterStatus.Size = New System.Drawing.Size(164, 21)
        Me.TextBoxPrinterStatus.TabIndex = 5
        '
        'ButtonPrintQrcode
        '
        Me.ButtonPrintQrcode.Location = New System.Drawing.Point(13, 178)
        Me.ButtonPrintQrcode.Name = "ButtonPrintQrcode"
        Me.ButtonPrintQrcode.Size = New System.Drawing.Size(131, 23)
        Me.ButtonPrintQrcode.TabIndex = 4
        Me.ButtonPrintQrcode.Text = "Print QR Code"
        Me.ButtonPrintQrcode.UseVisualStyleBackColor = True
        '
        'ButtonPrintReceipt
        '
        Me.ButtonPrintReceipt.Location = New System.Drawing.Point(13, 139)
        Me.ButtonPrintReceipt.Name = "ButtonPrintReceipt"
        Me.ButtonPrintReceipt.Size = New System.Drawing.Size(131, 23)
        Me.ButtonPrintReceipt.TabIndex = 3
        Me.ButtonPrintReceipt.Text = "Print Receipt"
        Me.ButtonPrintReceipt.UseVisualStyleBackColor = True
        '
        'ButtonCheckCashDrawerStatus
        '
        Me.ButtonCheckCashDrawerStatus.Location = New System.Drawing.Point(13, 100)
        Me.ButtonCheckCashDrawerStatus.Name = "ButtonCheckCashDrawerStatus"
        Me.ButtonCheckCashDrawerStatus.Size = New System.Drawing.Size(131, 23)
        Me.ButtonCheckCashDrawerStatus.TabIndex = 2
        Me.ButtonCheckCashDrawerStatus.Text = "Check CashDrawer Status"
        Me.ButtonCheckCashDrawerStatus.UseVisualStyleBackColor = True
        '
        'ButtonOpenCashDrawer
        '
        Me.ButtonOpenCashDrawer.Location = New System.Drawing.Point(13, 61)
        Me.ButtonOpenCashDrawer.Name = "ButtonOpenCashDrawer"
        Me.ButtonOpenCashDrawer.Size = New System.Drawing.Size(131, 23)
        Me.ButtonOpenCashDrawer.TabIndex = 1
        Me.ButtonOpenCashDrawer.Text = "Open CashDrawer"
        Me.ButtonOpenCashDrawer.UseVisualStyleBackColor = True
        '
        'ButtonGetPrinterStatus
        '
        Me.ButtonGetPrinterStatus.Location = New System.Drawing.Point(12, 20)
        Me.ButtonGetPrinterStatus.Name = "ButtonGetPrinterStatus"
        Me.ButtonGetPrinterStatus.Size = New System.Drawing.Size(132, 23)
        Me.ButtonGetPrinterStatus.TabIndex = 0
        Me.ButtonGetPrinterStatus.Text = "Get Status"
        Me.ButtonGetPrinterStatus.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonClose)
        Me.GroupBox2.Controls.Add(Me.ButtonOpen)
        Me.GroupBox2.Controls.Add(Me.ComboBoxBaudrate)
        Me.GroupBox2.Controls.Add(Me.ComboBoxPortName)
        Me.GroupBox2.Controls.Add(Me.TextBoxHost)
        Me.GroupBox2.Controls.Add(Me.RadioButtonNet)
        Me.GroupBox2.Controls.Add(Me.RadioButtonCom)
        Me.GroupBox2.Controls.Add(Me.RadioButtonUsb)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(349, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(387, 289)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Interface"
        '
        'ButtonClose
        '
        Me.ButtonClose.Enabled = False
        Me.ButtonClose.Location = New System.Drawing.Point(188, 216)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 14
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ButtonOpen
        '
        Me.ButtonOpen.Location = New System.Drawing.Point(98, 216)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpen.TabIndex = 13
        Me.ButtonOpen.Text = "Open"
        Me.ButtonOpen.UseVisualStyleBackColor = True
        '
        'ComboBoxBaudrate
        '
        Me.ComboBoxBaudrate.FormattingEnabled = True
        Me.ComboBoxBaudrate.Items.AddRange(New Object() {"9600", "19200", "38400", "57600", "115200"})
        Me.ComboBoxBaudrate.Location = New System.Drawing.Point(216, 61)
        Me.ComboBoxBaudrate.Name = "ComboBoxBaudrate"
        Me.ComboBoxBaudrate.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxBaudrate.TabIndex = 10
        '
        'ComboBoxPortName
        '
        Me.ComboBoxPortName.FormattingEnabled = True
        Me.ComboBoxPortName.Items.AddRange(New Object() {"COM0", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15", "COM16"})
        Me.ComboBoxPortName.Location = New System.Drawing.Point(83, 61)
        Me.ComboBoxPortName.Name = "ComboBoxPortName"
        Me.ComboBoxPortName.Size = New System.Drawing.Size(121, 20)
        Me.ComboBoxPortName.TabIndex = 9
        '
        'TextBoxHost
        '
        Me.TextBoxHost.Location = New System.Drawing.Point(83, 95)
        Me.TextBoxHost.Name = "TextBoxHost"
        Me.TextBoxHost.Size = New System.Drawing.Size(254, 21)
        Me.TextBoxHost.TabIndex = 8
        '
        'RadioButtonNet
        '
        Me.RadioButtonNet.AutoSize = True
        Me.RadioButtonNet.Location = New System.Drawing.Point(20, 100)
        Me.RadioButtonNet.Name = "RadioButtonNet"
        Me.RadioButtonNet.Size = New System.Drawing.Size(41, 16)
        Me.RadioButtonNet.TabIndex = 2
        Me.RadioButtonNet.TabStop = True
        Me.RadioButtonNet.Text = "NET"
        Me.RadioButtonNet.UseVisualStyleBackColor = True
        '
        'RadioButtonCom
        '
        Me.RadioButtonCom.AutoSize = True
        Me.RadioButtonCom.Location = New System.Drawing.Point(20, 66)
        Me.RadioButtonCom.Name = "RadioButtonCom"
        Me.RadioButtonCom.Size = New System.Drawing.Size(41, 16)
        Me.RadioButtonCom.TabIndex = 1
        Me.RadioButtonCom.TabStop = True
        Me.RadioButtonCom.Text = "COM"
        Me.RadioButtonCom.UseVisualStyleBackColor = True
        '
        'RadioButtonUsb
        '
        Me.RadioButtonUsb.AutoSize = True
        Me.RadioButtonUsb.Checked = True
        Me.RadioButtonUsb.Location = New System.Drawing.Point(20, 27)
        Me.RadioButtonUsb.Name = "RadioButtonUsb"
        Me.RadioButtonUsb.Size = New System.Drawing.Size(41, 16)
        Me.RadioButtonUsb.TabIndex = 0
        Me.RadioButtonUsb.TabStop = True
        Me.RadioButtonUsb.Text = "USB"
        Me.RadioButtonUsb.UseVisualStyleBackColor = True
        '
        'ExampleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 289)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ExampleForm"
        Me.Text = "POS Windows SDK"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBoxPrinterStatus As TextBox
    Friend WithEvents ButtonPrintQrcode As Button
    Friend WithEvents ButtonPrintReceipt As Button
    Friend WithEvents ButtonCheckCashDrawerStatus As Button
    Friend WithEvents ButtonOpenCashDrawer As Button
    Friend WithEvents ButtonGetPrinterStatus As Button
    Friend WithEvents ButtonPrintBarcode As Button
    Friend WithEvents TextBoxCashDrawerStatus As TextBox
    Friend WithEvents RadioButtonNet As RadioButton
    Friend WithEvents RadioButtonCom As RadioButton
    Friend WithEvents RadioButtonUsb As RadioButton
    Friend WithEvents TextBoxHost As TextBox
    Friend WithEvents ComboBoxBaudrate As ComboBox
    Friend WithEvents ComboBoxPortName As ComboBox
    Friend WithEvents ButtonClose As Button
    Friend WithEvents ButtonOpen As Button
    Friend WithEvents printImageBtn As Button
End Class
