using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices.ComTypes;

namespace WinFormUSB
{
    public partial class Form1 : Form
    {
        public string printePort { get; set; } = "";
        IntPtr printer;
        public Form1()
        {
            InitializeComponent();
            GetComPort();
            printer = InitPrinter("");
        }
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
        public static extern int PrinterInitialize(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int SetTextLineSpace(IntPtr intPtr, int lineSpace);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int CancelPrintDataInPageMode(IntPtr intPtr);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int GetPrinterState(IntPtr intPtr, ref int printerStatus);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int SetCodePage(IntPtr intPtr, int characterSet);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int SetInternationalCharacter(IntPtr intPtr, int characterSet);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int CutPaper(IntPtr intPtr, int cutMode);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int CutPaperWithDistance(IntPtr intPtr, int distance);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int FeedLine(IntPtr intPtr, int lines);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int OpenCashDrawer(IntPtr intPtr, int pinMode, int onTime, int ofTime);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int PrintText(IntPtr intPtr, string data, int alignment, int textSize);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int PrintTextS(IntPtr intPtr, string data);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int PrintBarCode(IntPtr intPtr, int bcType, string bcData, int width, int height, int alignment, int hriPosition);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int PrintSymbol(IntPtr intPtr, int type, string data, int errLevel, int width, int height, int alignment);
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int PrintImage(IntPtr intPtr, string filePath, int scaleMode);
        
        //---
        //俱家Α
        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int SelectPageMode(IntPtr intPtr);//砞﹚家Α

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int SelectPrintDirectionInPageMode(IntPtr intPtr, int direction);//家Α匡拒诀よ度家ΑΤ

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int SetHorizontalAndVerticalMotionUnits(IntPtr intPtr, int horizontal, int vertical);//砞﹚笲笆虫

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int SetPrintAreaInPageMode(IntPtr intPtr, int horizontal, int vertical, int width, int height);//家Α砞﹚跋办㎝呸胯翴跋办糴㎝蔼

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int SetAbsolutePrintPosition(IntPtr intPtr, int position);//盢竚眖オ娩絫簿笆 n ⊙キ┪笲笆虫

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int SetAbsoluteVerticalPrintPositionInPageMode(IntPtr intPtr, int position);//家Α砞﹚竚讽癬﹍竚オà┪à琌竚砞﹚

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int PrintDataInPageMode(IntPtr intPtr);//家Α计沮ぃ夹非家Α度家ΑΤ

        [DllImport("printer.sdk.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int SelectStandardMode(IntPtr intPtr);//パ家Αち传夹非家Α度家ΑΤ
        //---俱家Α




        int portflag = 0;
        int openStatus;

        //Open device
        private void button2_Click(object sender, EventArgs e)
        {
            if (openStatus==0)
            {
                ClosePort(printer);
            }
            switch (portflag)
            {
                case 0:
                    openStatus = OpenPort(printer, "USB,");
                    if (openStatus == 0)
                    {
                        MessageBox.Show("USB port opened!");
                        EnableBtn(true);
                    }
                    else
                    {
                        MessageBox.Show("Fail to open USB port, please check!");
                    };
                    break;
                case 1:
                    openStatus = OpenPort(printer, $"{comportbox.Text},{combaudratebox.Text}");
                    if (openStatus == 0)
                    {
                        MessageBox.Show("COM Port opened at port " + comportbox.Text + " and baudrate" + combaudratebox.Text);
                        EnableBtn(true);
                    }
                    else
                    {
                        MessageBox.Show("Fail to open COM port, please check!");
                    };
                    break;
                case 2:
                    openStatus = OpenPort(printer, $"NET,{textBoxIPaddress.Text}");
                    if (openStatus != 0)
                    {
                        MessageBox.Show("Fail to open NET port, please check!");
                    }
                    else
                    {
                        MessageBox.Show("Connect succeed!");
                        EnableBtn(true);
                    }
                    break;
            }

        }

        private void EnableBtn(bool e)
        {
            PageMode.Enabled = e;
            button_GetStatus.Enabled = e;
            Opencashdrawer.Enabled = e;
            buttonOpenCD.Enabled = e;
            button_receipt.Enabled = e;
            button_qr.Enabled = e;
            Printbarcode.Enabled = e;
            printImage.Enabled = e;
            buttonClose.Enabled = e;
            buttonOpen.Enabled = !e;
        }


        public void GetComPort()
        {
            string[] str = SerialPort.GetPortNames();
            if (str != null)
            {
                foreach (var item in str)
                {
                    comportbox.Items.Add(item);
                }
            }
        }
        //Close device port
        private void button3_Click(object sender, EventArgs e)
        {
            switch (portflag)
            {
                case 0:
                    if (openStatus == 0)
                    {
                        ClosePort(printer);
                        openStatus = 100;
                        buttonClose.Enabled = false;
                    }
                    break;
                case 1:
                    if (openStatus == 0)
                    {
                        ClosePort(printer);
                        openStatus = 100;
                        comportbox.Enabled = false;
                        combaudratebox.Enabled = false;
                    }
                    break;
                case 2:
                    if (openStatus == 0)
                    {
                        ClosePort(printer);
                        openStatus = 100;
                        textBoxIPaddress.Enabled = true;
                    }
                    break;
            }
            EnableBtn(false);

        }
        //Open cashdrawer
        private void Opencashdrawer_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                OpenCashDrawer(printer, 0, 30, 255);
            }
            else
            {
                MessageBox.Show("Fail to send data, please check connection!");

            }
        }

        //printer 1D barcode
        private void Printbarcode_Click_1(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                PrintBarCode(printer, 73, "1234567890", 3, 150, 0, 2);
                CutPaperWithDistance(printer, 40);
            }
            else
            {
                MessageBox.Show("Fail to send data, please check connection!");
            }
        }

        //print sample receipt 
        private void button_receipt_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                PrintText(printer, "Las vegas,NV5208\r\n", 1, 0);
                FeedLine(printer, 2);
                PrintText(printer, "Ticket #30-57320             User:HAPPY\r\n", 0, 0);
                PrintText(printer, "Station:52-102          Sales Rep HAPPY\r\n", 0, 0);
                PrintText(printer, "10/10/2019 3:55:01PM\r\n", 0, 0);
                PrintText(printer, "---------------------------------------\r\n", 0, 0);
                PrintText(printer, "Item         QTY         Price    Total\r\n", 0, 0);
                PrintText(printer, "Description\r\n", 0, 0);
                PrintText(printer, "---------------------------------------\r\n", 0, 0);
                PrintText(printer, "100328       1           7.99      7.99\r\n", 0, 0);
                PrintText(printer, "MAGARITA MIX 7           7.99      3.96\r\n", 0, 0);
                PrintText(printer, "680015       1          43.99     43.99\r\n", 0, 0);
                PrintText(printer, "LIME\r\n", 0, 0);
                PrintText(printer, "102501       1          43.99     43.99\r\n", 0, 0);
                PrintText(printer, "V0DKA\r\n", 0, 0);
                PrintText(printer, "021048       1           3.99      3.99\r\n", 0, 0);
                PrintText(printer, "ORANGE 3200Z\r\n", 0, 0);
                PrintText(printer, "---------------------------------------\r\n", 0, 0);
                PrintText(printer, "Subtobal                          60.93\r\n", 0, 0);
                PrintText(printer, "8.1% Sales Tax                     3.21\r\n", 0, 0);
                PrintText(printer, "2% Concession Recov                1.04\r\n", 0, 0);
                PrintText(printer, "---------------------------------------\r\n", 0, 0);
                PrintText(printer, "Total                             66.18\r\n", 0, 0);
                PrintBarCode(printer, 73, "1234567890", 3, 100, 0, 2);
                CutPaperWithDistance(printer, 66);
            }

        }


        //print sample qr code
        private void button_qr_Click(object sender, EventArgs e)
        {
            string test = "Hello World!";
            if (openStatus == 0)
            {
                PrintSymbol(printer, 49, test, 48, 10, 10, 1);
                CutPaperWithDistance(printer, 40);
            }
            else
            {
                MessageBox.Show("Fail to send data, please check connection!");
            }

        }

        //Printer Status Check command
        private void button_GetStatus_Click(object sender, EventArgs e)
        {
            returnvalue.Text = "";
            int status = 2;
            int ret;
            if (openStatus == 0)
            {
                ret = GetPrinterState(printer, ref status);
                if (ret == 0)
                {
                    if (0x12 == status)
                    {
                        returnvalue.Text = "Ready";
                    }
                    else if ((status & 0b100) > 0)
                    {
                        returnvalue.Text = "Cover opened";
                    }
                    else if ((status & 0b1000) > 0)
                    {
                        returnvalue.Text = "Feed button has been pressed";
                    }
                    else if ((status & 0b100000) > 0)
                    {
                        returnvalue.Text = "Printer is out of paper";
                    }
                    else if ((status & 0b1000000) > 0)
                    {
                        returnvalue.Text = "Error condition";
                    }
                    else
                    {
                        returnvalue.Text = "Other Error";
                    }
                }
                else
                {
                }
            }
        }

        //Check CashDrawer Status
        private void buttonCheckCDStatus_Click(object sender, EventArgs e)
        {
            int status = 1;
            if (openStatus == 0)
            {
                int ret = GetPrinterState(printer, ref status);
                if (ret > 0)
                {
                    if ((status & 0b100) > 0)
                    {
                        CD_Status.Text = "Cash Drawer Closed";
                    }
                    else
                    {
                        CD_Status.Text = "Cash Drawer Opened";
                    }
                }
                else
                {
                    CD_Status.Text = "uniRead failed";
                }
            }
        }

        private void radio_usb_CheckedChanged(object sender, EventArgs e)
        {
            portflag = 0;
            comportbox.Enabled = false;
            combaudratebox.Enabled = false;
            textBoxIPaddress.Enabled = false;
        }

        private void radiocom_CheckedChanged(object sender, EventArgs e)
        {
            portflag = 1;
            comportbox.Enabled = true;
            combaudratebox.Enabled = true;
            textBoxIPaddress.Enabled = false;
        }

        private void radionet_CheckedChanged(object sender, EventArgs e)
        {
            portflag = 2;
            textBoxIPaddress.Enabled = true;
        }

        private void printImage_Click(object sender, EventArgs e)
        {
            //Bitmap newMap;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files(*.*)|*.*";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory.ToString();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PrintImage(printer, openFileDialog1.FileName, 0);
                CutPaperWithDistance(printer, 40);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReleasePrinter(printer);
        }

        private void PageMode_Click(object sender, EventArgs e)
        {
            int intResult = -1;//ERROR_CM_SUCCESS 0 success
            intResult = SelectStandardMode(printer);//パ家Αち传夹非家Α度家ΑΤ Switch from page mode to standard mode (only effective in page mode).

            intResult = SelectPageMode(printer);//砞﹚家Α
            intResult = SelectPrintDirectionInPageMode(printer,0);//家Α匡拒诀よ度家ΑΤIn page mode, select printer print direction. This function is only effective in page mode.
            intResult = SetPrintAreaInPageMode(printer,0,0,570,570);//家Α砞﹚跋办㎝呸胯翴跋办糴㎝蔼
            intResult = PrintDataInPageMode(printer);//家Α计沮ぃ夹非家Α度家ΑΤ
            intResult = SetAbsolutePrintPosition(printer, 0);//盢竚眖オ娩絫簿笆 n ⊙キ┪笲笆虫
            intResult = SetAbsoluteVerticalPrintPositionInPageMode(printer, 0);//家Α砞﹚竚讽癬﹍竚オà┪à琌竚砞﹚
            intResult = PrintText(printer, "Las vegas,NV5208\r\n", 0, 0);
            intResult = PrintDataInPageMode(printer);//家Α计沮ぃ夹非家Α度家ΑΤ
            
            intResult = SelectStandardMode(printer);//パ家Αち传夹非家Α度家ΑΤ
            CutPaperWithDistance(printer, 0);

        }
    }
}
