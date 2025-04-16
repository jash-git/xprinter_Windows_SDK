using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace WinSDKDemo_ZPL
{
    public partial class Form1 : Form
    {
        public string printePort { get; set; } = "";
        IntPtr printer;
        public Form1()
        {
            InitializeComponent();
            GetComPort();
            printer = ZPLPrint.InitPrinter("");
        }
        public void GetComPort()
        {
            string[] str = SerialPort.GetPortNames();
            if (str != null)
            {
                foreach (var item in str)
                {
                    cb_COMName.Items.Add(item);
                }
            }
        }
        int portflag = 0;
        int openStatus = 999;
        private void rb_USB_CheckedChanged(object sender, EventArgs e)
        {
            portflag = 0;
            cb_COMName.Enabled = false;
            cb_BaudRate.Enabled = false;
            tb_IP.Enabled = false;
        }

        private void rb_COM_CheckedChanged(object sender, EventArgs e)
        {
            portflag = 1;
            cb_COMName.Enabled = true;
            cb_BaudRate.Enabled = true;
            tb_IP.Enabled = false;
        }

        private void rb_NET_CheckedChanged(object sender, EventArgs e)
        {
            portflag = 2;
            cb_COMName.Enabled = false;
            cb_BaudRate.Enabled = false;
            tb_IP.Enabled = true;
        }
        public void PortOeen()
        {
            rb_COM.Enabled = true;
            rb_NET.Enabled = true;
            rb_USB.Enabled = true;
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            if (openStatus==0)
            {
                ZPLPrint.ClosePort(printer);
            }
            switch (portflag)
            {
                case 0:
                    openStatus = ZPLPrint.OpenPort(printer, "USB,");
                    if (openStatus == 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "USB port opened!" + "\r\n";
                        PortStatus(portflag);
                    }
                    else
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to open USB port, please check!" + "\r\n";
                    };
                    break;
                case 1:
                    openStatus = ZPLPrint.OpenPort(printer, $"{cb_COMName.Text},{cb_BaudRate.Text}");
                    if (openStatus == 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "COM Port opened at port " + cb_COMName.Text + " and baudrate" + cb_BaudRate.Text + "\r\n";
                        PortStatus(portflag);
                    }
                    else
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to open COM port, please check!" + "\r\n";
                    };
                    break;
                case 2:
                    openStatus = ZPLPrint.OpenPort(printer, $"NET,{tb_IP.Text}");
                    if (openStatus != 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to open NET port, please check!" + "\r\n";
                    }
                    else
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Connect succeed!" + "\r\n";
                        PortStatus(portflag);
                    }
                    break;
            }
        }
        private void PortStatus(int port)
        {
            if (port == 0)
            {
                rb_COM.Enabled = false;
                rb_NET.Enabled = false;
            }
            else if (port == 1)
            {
                rb_USB.Enabled = false;
                rb_NET.Enabled = false;
            }
            else if (port == 2)
            {
                rb_USB.Enabled = false;
                rb_COM.Enabled = false;
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            switch (portflag)
            {
                case 0:
                    if (openStatus == 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "USB port closed!" + "\r\n";
                        ZPLPrint.ClosePort(printer);
                        PortOeen();
                        openStatus = 100;
                    }
                    break;
                case 1:
                    if (openStatus == 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "COM port closed!" + "\r\n";
                        ZPLPrint.ClosePort(printer);
                        PortOeen();
                        openStatus = 100;
                    }
                    break;
                case 2:
                    if (openStatus == 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "NET port closed!" + "\r\n";
                        ZPLPrint.ClosePort(printer);
                        PortOeen();
                        openStatus = 100;
                    }
                    break;
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ZPLPrint.ReleasePrinter(printer);
        }

        private void btn_Text_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                ZPLPrint.ZPL_StartFormat(printer);
                ZPLPrint.ZPL_Text(printer, 120, 20, 12, 0, 15, 12, "Welcome to the world of printing!");
                ZPLPrint.ZPL_EndFormat(printer);
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print text secceed." + "\r\n";
            }
            else
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + "\r\n";
            }
        }

        private void btn_Barcode_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                ZPLPrint.ZPL_StartFormat(printer);
                ZPLPrint.ZPL_BarCode128(printer, 120, 10, 0, 3, 80, 'Y', 'N', 'N', 'A', "123456");
                ZPLPrint.ZPL_EndFormat(printer);
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print BarCode128 secceed." + "\r\n";
            }
            else
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + "\r\n";
            }
        }

        private void btn_Qrcode_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                ZPLPrint.ZPL_StartFormat(printer);
                ZPLPrint.ZPL_QRCode(printer, 120, 5, 0, 2, 5, 'Q', '0', 'B', "Welcome to the world of printing!");
                ZPLPrint.ZPL_EndFormat(printer);
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print Qrcode secceed." + "\r\n";
            }
            else
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + "\r\n";
            }
        }

        private void btn_DataMatrix_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                ZPLPrint.ZPL_StartFormat(printer);
                ZPLPrint.ZPL_DataMatrixBarcode(printer, 120, 10, 0, 8, 100, 5, 4, 5, 1, "ABCDEFG1235ABCDEFG1235!@#$%^&");
                ZPLPrint.ZPL_EndFormat(printer);
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print DataMatrix secceed." + "\r\n";
            }
            else
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + "\r\n";
            }
        }

        private void btn_Box_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                ZPLPrint.ZPL_StartFormat(printer);
                ZPLPrint.ZPL_GraphicBox(printer, 120, 10, 400, 150, 5, 0);
                ZPLPrint.ZPL_EndFormat(printer);
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print Box secceed." + "\r\n";
            }
            else
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + "\r\n";
            }
        }

        private void btn_PrintConfiguration_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                ZPLPrint.ZPL_StartFormat(printer);
                ZPLPrint.ZPL_PrintConfigurationLabel(printer);
                ZPLPrint.ZPL_EndFormat(printer);
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Printer Configuration secceed." + "\r\n";

            }
            else
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + "\r\n";
            }
        }

        private void btn_BitMap_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files(*.*)|*.*";
                openFileDialog1.InitialDirectory = Environment.CurrentDirectory.ToString();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ZPLPrint.ZPL_StartFormat(printer);
                    ZPLPrint.ZPL_PrintImage(printer, 120, 20, openFileDialog1.FileName);
                    ZPLPrint.ZPL_EndFormat(printer);
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print BitMap secceed." + "\r\n";
                }
            }
            else
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + "\r\n";
            }
        }

        private void btn_TextBlock_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                ZPLPrint.ZPL_StartFormat(printer);
                ZPLPrint.ZPL_Text_Block(printer, 100, 20, 14, 0, 15, 12, 400, 200, "Welcome to the world of printing!");
                ZPLPrint.ZPL_EndFormat(printer);
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print TextBlock secceed." + "\r\n";
            }
            else
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + "\r\n";
            }
        }

        private void btn_PrinterStatus_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                int ret = ZPLPrint.ZPL_GetPrinterStatus(printer, out int status);
                if (ret != 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Read Error!" + "\r\n";
                }
                else if (status == 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Printer normal!" + "\r\n";
                }
                else if ((status & 0b01) > 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "The print head is opened！" + "\r\n";
                }
                else if ((status & 0b10) > 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Paper jam！" + "\r\n";
                }
                else if ((status & 0b100) > 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Out of paper！" + "\r\n";
                }
                else if ((status & 0b1000) > 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Out of ribbon！" + "\r\n";
                }
                else if ((status & 0b10000) > 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print pause！" + "\r\n";
                }
                else if ((status & 0b100000) > 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Printing！" + "\r\n";
                }
                else if ((status & 0b1000000) > 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Cover opened！" + "\r\n";
                }
                else
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Other error！" + "\r\n";
                }
            }
            else
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + "\r\n";
            }
        }

        private void btn_PDF417_Click(object sender, EventArgs e)
        {
            if (openStatus == 0)
            {
                ZPLPrint.ZPL_StartFormat(printer);
                ZPLPrint.ZPL_Pdf417(printer, 120, 10, 0, 4, 5, 3, 3, 20, 'N', "ASDFGH12345678");
                ZPLPrint.ZPL_EndFormat(printer);
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Print PDF417 secceed." + "\r\n";
            }
            else
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to send data, please check connection! " + "\r\n";
            }
        }

        private void tb_Msg_TextChanged(object sender, EventArgs e)
        {
            tb_Msg.SelectionStart = tb_Msg.TextLength;
            tb_Msg.ScrollToCaret();
        }
    }
}
