Imports System.IO.Ports

Public Class Form1
    Dim portflag = 0
    Dim openStatus = -1
    Private Sub GetCOMPort()
        Dim ports As String() = SerialPort.GetPortNames()
        Dim port As String
        For Each port In ports
            cb_COMName.Items.Add(port)
        Next port
    End Sub

    Dim printer = 0
    Private Sub btn_Open_Click(sender As Object, e As EventArgs) Handles btn_Open.Click
        If printer <> 0 Then
            ReleasePrinter(printer)
        End If
        printer = InitPrinter("")
        If portflag = 0 Then
            openStatus = ZPLPrint.OpenPort(printer, "USB,")
            If openStatus = 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "USB port opened!" + vbCrLf
                PortStatus(portflag)
            Else
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to open USB port, please check!" + vbCrLf
            End If
        ElseIf portflag = 1 Then
            openStatus = ZPLPrint.OpenPort(printer, $"{cb_COMName.Text},{cb_BaudRate.Text}")
            If openStatus = 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "COM Port opened at port " + cb_COMName.Text + " and baudrate" + cb_BaudRate.Text + vbCrLf
                PortStatus(portflag)
            Else
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to open COM port, please check!" + vbCrLf
            End If
        ElseIf portflag = 2 Then
            openStatus = ZPLPrint.OpenPort(printer, $"NET,{tb_IP.Text}")
            If openStatus <> 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to open NET port, please check!" + vbCrLf
            Else
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "NET port connect secceed!" + vbCrLf
                PortStatus(portflag)
            End If
        End If

    End Sub
    Private Sub PortStatus(port As Integer)
        If port = 0 Then
            rb_COM.Enabled = False
            rb_NET.Enabled = False
        ElseIf port = 1 Then
            rb_USB.Enabled = False
            rb_NET.Enabled = False
        ElseIf port = 2 Then
            rb_USB.Enabled = False
            rb_COM.Enabled = False
        End If
    End Sub
    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        If portflag = 0 Then
            If openStatus = 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "USB port closed!" + vbCrLf
                ZPLPrint.ClosePort(printer)
                openStatus = 100
                PortOpen()
            End If
        ElseIf portflag = 1 Then
            If openStatus = 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "COM port closed!" + vbCrLf
                ZPLPrint.ClosePort(printer)
                openStatus = 100
                PortOpen()
            End If
        ElseIf portflag = 2 Then
            If openStatus = 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "NET port closed!" + vbCrLf
                ZPLPrint.ClosePort(printer)
                openStatus = 100
                PortOpen()
            End If

        End If
    End Sub
    Private Sub PortOpen()
        rb_COM.Enabled = True
        rb_NET.Enabled = True
        rb_USB.Enabled = True
    End Sub
    Private Sub btn_Text_Click(sender As Object, e As EventArgs) Handles btn_Text.Click
        If openStatus = 0 Then
            ZPLPrint.ZPL_StartFormat(printer)
            ZPLPrint.ZPL_Text(printer, 120, 20, 12, 0, 15, 12, "Welcome to the world of printing!")
            ZPLPrint.ZPL_EndFormat(printer)
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print text secceed." + vbCrLf
        Else
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + vbCrLf
        End If
    End Sub

    Private Sub btn_Qrcode_Click(sender As Object, e As EventArgs) Handles btn_Qrcode.Click
        If openStatus = 0 Then
            ZPLPrint.ZPL_StartFormat(printer)
            ZPLPrint.ZPL_QRCode(printer, 120, 5, 0, 2, 5, "Q", "0", "B", "Welcome to the world of printing!")
            ZPLPrint.ZPL_EndFormat(printer)
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print Qrcode secceed." + vbCrLf
        Else
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + vbCrLf
        End If
    End Sub

    Private Sub btn_DataMatrix_Click(sender As Object, e As EventArgs) Handles btn_DataMatrix.Click
        If openStatus = 0 Then
            ZPLPrint.ZPL_StartFormat(printer)
            ZPLPrint.ZPL_DataMatrixBarcode(printer, 120, 10, 0, 8, 100, 5, 4, 5, 1, "ABCDEFG1235ABCDEFG1235!@#$%^&")
            ZPLPrint.ZPL_EndFormat(printer)
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print DataMatrix secceed." + vbCrLf
        Else
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + vbCrLf
        End If
    End Sub

    Private Sub btn_Box_Click(sender As Object, e As EventArgs) Handles btn_Box.Click
        If openStatus = 0 Then
            ZPLPrint.ZPL_StartFormat(printer)
            ZPLPrint.ZPL_GraphicBox(printer, 120, 10, 400, 150, 5, 0)
            ZPLPrint.ZPL_EndFormat(printer)
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print Box secceed." + vbCrLf
        Else
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + vbCrLf
        End If
    End Sub

    Private Sub btn_PrinterConfiguration_Click(sender As Object, e As EventArgs) Handles btn_PrinterConfiguration.Click
        If openStatus = 0 Then
            ZPLPrint.ZPL_StartFormat(printer)
            ZPLPrint.ZPL_PrintConfigurationLabel(printer)
            ZPLPrint.ZPL_EndFormat(printer)
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print Configuration secceed." + vbCrLf
        Else
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + vbCrLf
        End If
    End Sub

    Private Sub btn_BitMap_Click(sender As Object, e As EventArgs) Handles btn_BitMap.Click
        If openStatus = 0 Then
            Dim fileDialog As New System.Windows.Forms.OpenFileDialog()
            fileDialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory
            fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            fileDialog.FilterIndex = 0
            fileDialog.RestoreDirectory = True
            fileDialog.Title = "select file"
            If fileDialog.ShowDialog = DialogResult.OK Then
                ZPLPrint.ZPL_StartFormat(printer)
                ZPLPrint.ZPL_PrintImage(printer, 120, 20, fileDialog.FileName)
                ZPLPrint.ZPL_EndFormat(printer)
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print BitMap secceed." + vbCrLf
            End If
        Else
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + vbCrLf
        End If

    End Sub

    Private Sub btn_TextBlock_Click(sender As Object, e As EventArgs) Handles btn_TextBlock.Click
        If openStatus = 0 Then
            ZPLPrint.ZPL_StartFormat(printer)
            ZPLPrint.ZPL_Text_Block(printer, 120, 20, 14, 0, 15, 12, 400, 200, "Welcome to the world of printing!")
            ZPLPrint.ZPL_EndFormat(printer)
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print TextBlock secceed." + vbCrLf
        Else
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + vbCrLf
        End If
    End Sub

    Private Sub btn_PrinterStatus_Click(sender As Object, e As EventArgs) Handles btn_PrinterStatus.Click

        Dim result As Integer, ret As Integer
        ret = ZPLPrint.ZPL_GetPrinterStatus(printer, result)
        If ret = 0 Then
            If result = 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Printer normal!" + vbCrLf
            ElseIf (result And &B1) > 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "The print head is opened！" + vbCrLf
            ElseIf (result And &B10) > 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Paper jam！" + vbCrLf
            ElseIf (result And &B100) > 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Out of paper！" + vbCrLf
            ElseIf (result And &B1000) > 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Out of ribbon！" + vbCrLf
            ElseIf (result And &B10000) > 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print pause！" + vbCrLf
            ElseIf (result And &B100000) > 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Printing！" + vbCrLf
            ElseIf (result And &B1000000) > 0 Then
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Cover opened！" + vbCrLf
            Else
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Other error！" + vbCrLf
            End If
        Else
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + vbCrLf
        End If
    End Sub

    Private Sub btn_PDF417_Click(sender As Object, e As EventArgs) Handles btn_PDF417.Click
        If openStatus = 0 Then
            ZPLPrint.ZPL_StartFormat(printer)
            ZPLPrint.ZPL_Pdf417(printer, 120, 10, 0, 4, 5, 3, 3, 20, "N", "ASDFGH12345678")
            ZPLPrint.ZPL_EndFormat(printer)
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print PDF417 secceed." + vbCrLf
        Else
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + vbCrLf
        End If
    End Sub

    Private Sub rb_USB_CheckedChanged(sender As Object, e As EventArgs) Handles rb_USB.CheckedChanged
        portflag = 0
        cb_COMName.Enabled = False
        cb_BaudRate.Enabled = False
        tb_IP.Enabled = False
    End Sub

    Private Sub rb_COM_CheckedChanged(sender As Object, e As EventArgs) Handles rb_COM.CheckedChanged
        portflag = 1
        cb_COMName.Enabled = True
        cb_BaudRate.Enabled = True
        tb_IP.Enabled = False
    End Sub

    Private Sub rb_NET_CheckedChanged(sender As Object, e As EventArgs) Handles rb_NET.CheckedChanged
        portflag = 2
        cb_COMName.Enabled = False
        cb_BaudRate.Enabled = False
        tb_IP.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCOMPort()
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ReleasePrinter(printer)
    End Sub

    Private Sub btn_Barcode_Click(sender As Object, e As EventArgs) Handles btn_Barcode.Click
        If openStatus = 0 Then
            ZPLPrint.ZPL_StartFormat(printer)
            ZPLPrint.ZPL_BarCode128(printer, 120, 10, 0, 3, 80, "Y", "N", "N", "A", "123456")
            ZPLPrint.ZPL_EndFormat(printer)
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print text secceed." + vbCrLf
        Else
            tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + vbCrLf
        End If
    End Sub

    Private Sub tb_Msg_TextChanged(sender As Object, e As EventArgs) Handles tb_Msg.TextChanged
        tb_Msg.SelectionStart = tb_Msg.TextLength
        tb_Msg.ScrollToCaret()
    End Sub
End Class
