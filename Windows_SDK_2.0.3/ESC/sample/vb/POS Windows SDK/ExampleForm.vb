
Public Class ExampleForm
    Private mPpStream As UIntPtr

    Private Function ArrayToBytes(arr As ArrayList) As Byte()
        Dim byteArr(arr.Count - 1) As Byte

        arr.CopyTo(byteArr)
        Return byteArr
    End Function

    Private Function ActionVerify() As Boolean
        If mPpStream = 0 Then
            MsgBox("There does not have any interface opened!", MsgBoxStyle.Critical)
            Return False

        End If

        Return True
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPrinterStatus.TextChanged

    End Sub

    Dim printer = 0
    Private Sub ButtonOpen_Click(sender As Object, e As EventArgs) Handles ButtonOpen.Click
        If printer <> 0 Then
            ReleasePrinter(printer)
        End If
        printer = InitPrinter("")
        If RadioButtonUsb.Checked Then
            Dim result = OpenPort(printer, "USB,")
            If result = 0 Then
                MsgBox("USB port opened!", MsgBoxStyle.Information)
                EnableBtn(True)
            Else
                MsgBox("Fail to open USB port, please check!", MsgBoxStyle.Critical)
            End If
        ElseIf RadioButtonCom.Checked Then
            Dim portName = ComboBoxPortName.Text.Trim()
            Dim baudrate
            Try
                baudrate = Integer.Parse(ComboBoxBaudrate.Text.Trim())
            Catch exce As FormatException
                baudrate = 0
            End Try
            If baudrate <= 0 Then
                MsgBox("Please specific a valid com baudrate!", MsgBoxStyle.Critical)
                Return
            End If
            Dim data As String = portName & "," & baudrate
            If OpenPort(printer, data) = 0 Then
                MsgBox("COM Port opened", MsgBoxStyle.Information)
                EnableBtn(True)
            Else
                MsgBox("Fail to open COM port, please check!", MsgBoxStyle.Critical)
            End If
        ElseIf RadioButtonNet.Checked Then
            Dim host = TextBoxHost.Text.Trim()

            If host.Length <= 0 Then
                MsgBox("Please input valid host!", MsgBoxStyle.Critical)
                Return
            End If
            If OpenPort(printer, "NET," & host) = 0 Then
                MsgBox("Connect succeed!", MsgBoxStyle.Information)
                EnableBtn(True)
            Else
                MsgBox("Fail to open NET port, please check!", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Please choose a valid interface!", MsgBoxStyle.Critical)
            Return
        End If

    End Sub

    Private Sub EnableBtn(e As Boolean)
        GroupBox1.Enabled = e
        ButtonClose.Enabled = e
        If e Then
            ButtonOpen.Enabled = False
        Else
            ButtonOpen.Enabled = True
        End If

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        If printer <> 0 Then
            ReleasePrinter(printer)
        End If
        EnableBtn(False)
    End Sub

    Private Sub ButtonPrintBarcode_Click(sender As Object, e As EventArgs) Handles ButtonPrintBarcode.Click
        PrintBarCode(printer, 73, "1234567890", 3, 150, 0, 2)
        If CutPaperWithDistance(printer, 10) <> 0 Then
            MsgBox("Fail to send data, please check connection!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub ButtonPrintQrcode_Click(sender As Object, e As EventArgs) Handles ButtonPrintQrcode.Click
        PrintSymbol(printer, 49, "Hello World", 48, 10, 10, 1)
        If CutPaperWithDistance(printer, 10) <> 0 Then
            MsgBox("Fail to send data, please check connection!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub ButtonPrintReceipt_Click(sender As Object, e As EventArgs) Handles ButtonPrintReceipt.Click
        PrinterInitialize(printer)
        SetRelativeHorizontal(printer, 180)
        PrintTextS(printer, "Las vegas,NV5208" & Chr(10))
        PrintAndFeedLine(printer)
        PrintAndFeedLine(printer)
        PrintTextS(printer, "Ticket #30-57320             User:HAPPY" & Chr(10))
        PrintTextS(printer, "Station:52-102          Sales Rep HAPPY" & Chr(10))
        PrintTextS(printer, "10/10/2019 3:55:01PM" & Chr(10))
        PrintTextS(printer, "---------------------------------------" & Chr(10))
        PrintTextS(printer, "Item         QTY         Price    Total" & Chr(10))
        PrintTextS(printer, "Description" & Chr(10))
        PrintTextS(printer, "---------------------------------------" & Chr(10))
        PrintTextS(printer, "100328       1           7.99      7.99" & Chr(10))
        PrintTextS(printer, "MAGARITA MIX 7           7.99      3.96" & Chr(10))
        PrintTextS(printer, "680015       1          43.99     43.99" & Chr(10))
        PrintTextS(printer, "LIME" & Chr(10))
        PrintTextS(printer, "102501       1          43.99     43.99" & Chr(10))
        PrintTextS(printer, "V0DKA" & Chr(10))
        PrintTextS(printer, "021048       1           3.99      3.99" & Chr(10))
        PrintTextS(printer, "ORANGE 3200Z" & Chr(10))
        PrintTextS(printer, "---------------------------------------" & Chr(10))
        PrintTextS(printer, "Subtobal                          60.93" & Chr(10))
        PrintTextS(printer, "8.1% Sales Tax                     3.21" & Chr(10))
        PrintTextS(printer, "2% Concession Recov                1.04" & Chr(10))
        PrintTextS(printer, "---------------------------------------" & Chr(10))
        PrintTextS(printer, "Total                             66.18" & Chr(10))
        PrintBarCode(printer, 73, "1234567890", 3, 150, 0, 2)
        CutPaperWithDistance(printer, 10)
    End Sub

    Private Sub ButtonOpenCashDrawer_Click(sender As Object, e As EventArgs) Handles ButtonOpenCashDrawer.Click
        OpenCashDrawer(printer, 0, 30, 255)
    End Sub

    Private Sub ButtonGetPrinterStatus_Click(sender As Object, e As EventArgs) Handles ButtonGetPrinterStatus.Click
        Dim status As Integer = 2
        Dim statusText
        Dim ret = GetPrinterState(printer, status)
        If ret = 0 Then
            statusText = PrinterStatusToText(status)
        Else
            statusText = "Failed to read from current interface."
        End If
        TextBoxPrinterStatus.Text = statusText
    End Sub

    Private Sub ButtonCheckCashDrawerStatus_Click(sender As Object, e As EventArgs) Handles ButtonCheckCashDrawerStatus.Click
        Dim status As Integer = 1
        Dim statusText
        Dim ret = GetPrinterState(printer, status)
        If ret > 0 Then
            statusText = CashDrawerStatusToText(status)
        Else
            statusText = "Failed to read from current interface."
        End If
        statusText = statusText
        TextBoxCashDrawerStatus.Text = statusText
    End Sub

    Private Sub printImage_Click(sender As Object, e As EventArgs) Handles printImageBtn.Click
        Dim obj As New System.Windows.Forms.OpenFileDialog
        obj.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        obj.InitialDirectory = Environment.CurrentDirectory.ToString()
        If obj.ShowDialog() = DialogResult.OK Then
            PrintImage(printer, obj.FileName, 0)
            If CutPaperWithDistance(printer, 10) <> 0 Then
                MsgBox("Fail to send data, please check connection!", MsgBoxStyle.Critical)
            End If
        End If




    End Sub
End Class
