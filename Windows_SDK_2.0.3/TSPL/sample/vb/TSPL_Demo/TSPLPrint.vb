Imports System.Runtime.InteropServices
Imports System.Text
Imports TSPL_Demo.EnumContainer

Module TSPLPrint

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
    Public Function TSPL_Text(handle As Long, x As Integer, y As Integer, fontName As String, content As String, rotation As Integer, x_multiplication As Integer, y_multiplication As Integer, alignment As Integer) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_Print(handle As Long, num As Integer, copies As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_Bar(handle As Long, x As Integer, y As Integer, width As Integer, height As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_BarCode(handle As Long, x As Integer, y As Integer, barcodeType As Integer, data As String, height As Integer, showText As Integer, rotation As Integer, narrow As Integer, wide As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_Image(handle As Long, x As Integer, y As Integer, mode As Integer, filePath As String) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_Setup(handle As Long, printSpeed As Integer, printDensity As Integer, labelWidth As Integer, labelHeight As Integer, labelType As Integer, gapHight As Integer, offset As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_ClearBuffer(handle As Long) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_Box(handle As Long, x As Integer, y As Integer, x_end As Integer, y_end As Integer, thickness As Integer, radius As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_QrCode(handle As Long, x As Integer, y As Integer, width As Integer, eccLevel As Integer, mode As Integer, rotate As Integer, model As Integer, mask As Integer, data As String) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_Home(handle As Long) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_GetPrinterStatus(handle As Long, ByRef printerStatus As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_PDF417(handle As Long, x As Integer, y As Integer, width As Integer, height As Integer, rotate As Integer, [option] As String, data As String) As Integer
    End Function
    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_Block(handle As Long, x As Integer, y As Integer, width As Integer, height As Integer, fontName As String, data As String, rotation As Integer, x_multiplication As Integer, y_multiplication As Integer, alignment As Integer) As Integer
    End Function

    <DllImport(POSPRINTERR, CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)>
    Public Function TSPL_Dmatrix(handle As Long, x As Integer, y As Integer, width As Integer, height As Integer, data As String, blockSize As Integer, row As Integer, col As Integer) As Integer
    End Function

End Module
