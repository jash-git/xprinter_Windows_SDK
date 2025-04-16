Imports System.Runtime.InteropServices

Module PosPrinter
    Public Const POSPRINTERR As String = "printer.sdk.dll"


    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function InitPrinter(ByVal model As String) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Unicode, CallingConvention:=CallingConvention.Cdecl)>
    Public Function OpenPort(handle As Long, ByVal setting As String) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ReleasePrinter(handle As Long) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function ReadData(handle As Long, buffer As Byte(), size As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function WriteData(handle As Long, buffer As Byte(), size As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrinterInitialize(handle As Long) As Integer
    End Function


    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrintTextS(handle As Long, data As String) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrintAndFeedLine(handle As Long) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrintBarCode(handle As Long, bcType As Integer, data As String, width As Integer, height As Integer, alignment As Integer, hriPosition As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function CutPaperWithDistance(handle As Long, distance As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrintSymbol(handle As Long, type As Integer, data As String, errLevel As Integer, width As Integer, height As Integer, alignment As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function GetPrinterState(handle As Long, ByRef intValue As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function SetRelativeHorizontal(handle As Long, position As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function OpenCashDrawer(handle As Long, pinMode As Integer, onTime As Integer, ofTime As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function PrintImage(handle As Long, imagePath As String, scaleMode As Integer) As Integer
    End Function

End Module
