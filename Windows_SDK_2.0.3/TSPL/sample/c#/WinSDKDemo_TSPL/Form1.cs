using System;
using System.IO.Ports;
using System.Windows.Forms;


namespace WinSDKDemo_TSPL
{
    public partial class Form1 : Form
    {
        public string printePort { get; set; } = "";
        IntPtr printer;
        public Form1()
        {
            InitializeComponent();
            GetComPort();
            printer = TSPLPrint.InitPrinter("");
        }
        int portflag = 0;
        int openStatus = 100;
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

        private void btn_Open_Click(object sender, EventArgs e)
        {
            if (openStatus==0)
            {
                TSPLPrint.ClosePort(printer);
            }
            switch (portflag)
            {
                case 0:
                    openStatus = TSPLPrint.OpenPort(printer, "USB,");
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
                    openStatus = TSPLPrint.OpenPort(printer, $"{cb_COMName.Text},{cb_BaudRate.Text}");
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
                    openStatus = TSPLPrint.OpenPort(printer, $"NET,{tb_IP.Text}");
                    if (openStatus != 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to open NET port, please check!" + "\r\n";
                    }
                    else
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "NET port connect secceed!" + "\r\n";
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
        public void PortOpen()
        {
            rb_COM.Enabled = true;
            rb_NET.Enabled = true;
            rb_USB.Enabled = true;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            switch (portflag)
            {
                case 0:
                    if (openStatus == 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "USB port closed!" + "\r\n";
                        TSPLPrint.ClosePort(printer);
                        PortOpen();
                        openStatus = 100;
                    }
                    break;
                case 1:
                    if (openStatus == 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "COM port closed!" + "\r\n";
                        TSPLPrint.ClosePort(printer);
                        PortOpen();
                        openStatus = 100;
                    }
                    break;
                case 2:
                    if (openStatus == 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "NET port closed!" + "\r\n";
                        TSPLPrint.ClosePort(printer);
                        PortOpen();
                        openStatus = 100;
                    }
                    break;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            TSPLPrint.ReleasePrinter(printer);
        }

        private void btn_PrinterStatus_Click(object sender, EventArgs e)
        {
            if (openStatus != 0)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                return;
            }
            int ret = TSPLPrint.TSPL_GetPrinterStatus(printer, out int status);
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

        private void btn_PDF417_Click(object sender, EventArgs e)
        {
            try
            {
                if (openStatus != 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                    return;
                }
                TSPLPrint.TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
                TSPLPrint.TSPL_ClearBuffer(printer);
                TSPLPrint.TSPL_PDF417(printer, 60, 60, 100, 200, 0, "E3,W3,L10", "ABCDEFGHIJKABCDEFGHIJK123456!@#$%^&");
                TSPLPrint.TSPL_Print(printer, 1, 1);
            }
            catch (Exception ex)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + ex.Message + "\r\n";
            }
        }

        private void btn_TextBlock_Click(object sender, EventArgs e)
        {
            try
            {
                if (openStatus != 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                    return;
                }
                TSPLPrint.TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
                TSPLPrint.TSPL_ClearBuffer(printer);
                TSPLPrint.TSPL_Block(printer, 20, 60, 600, 200, "3", "Welcome to the world of printing ! Welcome to the world of printing! ", 0, 1, 1, 0);
                TSPLPrint.TSPL_Print(printer, 1, 1);
            }
            catch (Exception ex)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + ex.Message + "\r\n";
            }
        }

        private void btn_BitMap_Click(object sender, EventArgs e)
        {
            if (openStatus != 0)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files(*.*)|*.*";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory.ToString();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TSPLPrint.TSPL_Setup(printer, 4, 8, 76, 50, 1, 2, 4);
                    TSPLPrint.TSPL_ClearBuffer(printer);
                    TSPLPrint.TSPL_Image(printer, 10, 0, 0, openFileDialog1.FileName);
                    TSPLPrint.TSPL_Print(printer, 1, 1);
                    TSPLPrint.TSPL_Home(printer);
                }
                catch (Exception ex)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + ex.Message + "\r\n";
                }

            }
        }
        private void btn_Box_Click(object sender, EventArgs e)
        {
            if (openStatus != 0)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                return;
            }
            try
            {
                TSPLPrint.TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
                TSPLPrint.TSPL_ClearBuffer(printer);
                TSPLPrint.TSPL_Box(printer, 60, 60, 400, 150, 5);
                TSPLPrint.TSPL_Print(printer, 1, 1);
            }
            catch (Exception ex)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + ex.Message + "\r\n";
            }
        }

        private void btn_Bar_Click(object sender, EventArgs e)
        {
            if (openStatus != 0)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                return;
            }
            try
            {
                TSPLPrint.TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
                TSPLPrint.TSPL_ClearBuffer(printer);
                TSPLPrint.TSPL_Bar(printer, 60, 60, 400, 30);
                TSPLPrint.TSPL_Print(printer, 1, 1);
            }
            catch (Exception ex)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + ex.Message + "\r\n";
            }
        }

        private void btn_Qrcode_Click(object sender, EventArgs e)
        {
            if (openStatus != 0)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                return;
            }
            try
            {
                TSPLPrint.TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
                TSPLPrint.TSPL_ClearBuffer(printer);
                TSPLPrint.TSPL_QrCode(printer, 60, 60, 7, 1, 1, 0, 1, 2, "TESTCODE1234");
                TSPLPrint.TSPL_Print(printer, 1, 1);
            }
            catch (Exception ex)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + ex.Message + "\r\n";
            }
        }

        private void btn_DataMatrix_Click(object sender, EventArgs e)
        {
            if (openStatus != 0)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                return;
            }
            try
            {
                TSPLPrint.TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
                TSPLPrint.TSPL_ClearBuffer(printer);
                TSPLPrint.TSPL_Dmatrix(printer, 60, 60, 50, 50, "abcdefg123456789!@#$%^&*()", 8);
                TSPLPrint.TSPL_Print(printer, 1, 1);
            }
            catch (Exception ex)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + ex.Message + "\r\n";
            }
        }

        private void btn_Text_Click(object sender, EventArgs e)
        {
            if (openStatus != 0)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                return;
            }
            try
            {
                TSPLPrint.TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
                TSPLPrint.TSPL_ClearBuffer(printer);
                TSPLPrint.TSPL_Text(printer, 80, 70, "3", "TEST", 0, 2, 2, 0);
                TSPLPrint.TSPL_Text(printer, 50, 150, "2", "Welcome to the world of printing!", 0, 1, 1, 0);
                TSPLPrint.TSPL_Print(printer, 1, 1);
            }
            catch (Exception ex)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + ex.Message + "\r\n";
            }

        }

        private void btn_Barcode_Click(object sender, EventArgs e)
        {
            if (openStatus != 0)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                return;
            }
            try
            {
                TSPLPrint.TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
                TSPLPrint.TSPL_ClearBuffer(printer);
                TSPLPrint.TSPL_BarCode(printer, 60, 60, 0, "123abcd", 80, 0, 0, 2, 2);
                TSPLPrint.TSPL_Print(printer, 1, 1);
            }
            catch (Exception ex)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + ex.Message + "\r\n";
            }
        }

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

        private void tb_Msg_TextChanged(object sender, EventArgs e)
        {
            tb_Msg.SelectionStart = tb_Msg.TextLength;
            tb_Msg.ScrollToCaret();
        }
    }
}
