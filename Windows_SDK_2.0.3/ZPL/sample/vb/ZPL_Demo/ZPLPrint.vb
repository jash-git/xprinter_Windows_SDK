Imports System.Runtime.InteropServices

Module ZPLPrint
    Public Const POSPRINTERR As String = "printer.sdk.dll"

    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function InitPrinter(ByVal model As String) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function OpenPort(handle As Long, ByVal setting As String) As Integer

    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ClosePort(handle As Long) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ReleasePrinter(handle As Long) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ReadData(handle As Long, buffer As Byte(), size As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function WriteData(handle As Long, buffer As Byte(), size As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_StartFormat(handle As Long) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_EndFormat(handle As Long) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_Text(handle As Long, xPos As Integer, yPos As Integer, fontNum As Integer, orientation As Integer, fontWidth As Integer, fontHeight As Integer, text As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_BarCode128(handle As Long, xPos As Integer, yPos As Integer, orientation As Integer, moduleWidth As Integer, codeHeight As Integer, line As Char, lineAboveCode As Char, checkDigit As Char, mode As Char, text As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_QRCode(handle As Long, xPos As Integer, yPos As Integer, orientation As Integer, model As Integer, dpi As Integer, eccLevel As Char, input As Char, charMode As Char, text As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_GraphicBox(handle As Long, xPos As Integer, yPos As Integer, width As Integer, height As Integer, thickness As Integer, rounding As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_PrintImage(handle As Long, xPos As Integer, yPos As Integer, imgName As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_DataMatrixBarcode(handle As Long, xPos As Integer, yPos As Integer, orientation As Integer, codeHeight As Integer, level As Integer, columns As Integer, rows As Integer, formatId As Integer, aspectRatio As Integer, text As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_Text_Block(handle As Long, xPos As Integer, yPos As Integer, fontNum As Integer, orientation As Integer, fontWidth As Integer, fontHeight As Integer, textblockWidth As Integer, textblockHeight As Integer, text As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_GetPrinterStatus(handle As Long, ByRef printerStatus As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_PrintConfigurationLabel(handle As Long) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_Pdf417(handle As Long, xPos As Integer, yPos As Integer, orientation As Integer, moduleWidth As Integer, codeHeight As Integer, securityLevel As Integer, columns As Integer, rows As Integer, truncate As Char, text As String) As Integer
    End Function


End Module
