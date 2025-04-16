using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace WinSDKDemo_ZPL
{
    public class ZPLPrint
    {
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern IntPtr InitPrinter(string model);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ReleasePrinter(IntPtr intPtr);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int OpenPort(IntPtr intPtr, string port);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ClosePort(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int WriteData(IntPtr intPtr, byte[] buffer, int size);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ReadData(IntPtr intPtr, byte[] buffer, int size);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_StartFormat(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_EndFormat(IntPtr intPtr);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_Text(IntPtr intPtr, int xPos, int yPos, int fontNum, int orientation, int fontWidth, int fontHeight, string text);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_Pdf417(IntPtr intPtr, int xPos, int yPos, int orientation, int moduleWidth, int codeHeight, int securityLevel, int columns, int rows, char truncate, string text);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_BarCode128(IntPtr intPtr, int xPos, int yPos, int orientation, int moduleWidth, int codeHeight, char line, char lineAboveCode, char checkDigit, char mode, string text);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_QRCode(IntPtr intPtr, int xPos, int yPos, int orientation, int model, int dpi, char eccLevel, char input, char charMode, string text);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_GraphicBox(IntPtr intPtr, int xPos, int yPos, int width, int height, int thickness, int rounding);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_PrintImage(IntPtr intPtr, int xPos, int yPos, string imgName);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_PrintConfigurationLabel(IntPtr intPtr);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_GetPrinterStatus(IntPtr intPtr, out int status);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_Text_Block(IntPtr intPtr, int xPos, int yPos, int fontNum, int orientation, int fontWidth, int fontHeight, int textblockWidth, int textblockHeight, string text);

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int ZPL_DataMatrixBarcode(IntPtr intPtr, int xPos, int yPos, int orientation, int codeHeight, int level, int columns, int rows, int formatId, int aspectRatio, string text);



    }
}
