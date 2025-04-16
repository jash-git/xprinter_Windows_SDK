Imports System.Runtime.InteropServices

Module CPCLPrint
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

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ReadData(handle As Long, buffer As Byte(), size As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function WriteData(handle As Long, buffer As Byte(), size As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_AddLabel(handle As Long, offSet As Integer, height As Integer, qty As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_SetAlign(handle As Long, align As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_AddText(handle As Long, rotate As Integer, fontName As String, fontSize As Integer, xPos As Integer, yPos As Integer, data As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_AddBarCode(handle As Long, rotate As Integer, type As Integer, width As Integer, ratio As Integer, height As Integer, xPos As Integer, yPos As Integer, data As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_AddBarCodeText(handle As Long, enable As Integer, fontType As Integer, fontSize As Integer, offset As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_AddQRCode(handle As Long, rotate As Integer, xPos As Integer, yPos As Integer, model As Integer, unitWidth As Integer, eccLevel As Integer, data As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_AddPDF417(handle As Long, rotate As Integer, xPos As Integer, yPos As Integer, xDots As Integer, yDots As Integer, columns As Integer, eccLevel As Integer, data As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_AddBox(handle As Long, xPos As Integer, yPos As Integer, endXPos As Integer, endYPos As Integer, thickness As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_AddLine(handle As Long, xPos As Integer, yPos As Integer, endXPos As Integer, endYPos As Integer, thickness As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_AddImage(handle As Long, rotate As Integer, xPos As Integer, yPos As Integer, filePath As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_SetTextUnderline(handle As Long, bunderlineold As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CPCL_Print(handle As Long) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ZPL_GetPrinterStatus(handle As Long, ByRef printerStatus As Integer) As Integer
    End Function

End Module
