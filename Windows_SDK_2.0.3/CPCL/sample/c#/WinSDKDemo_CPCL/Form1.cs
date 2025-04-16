using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace WinSDKDemo_CPCL
{
    public partial class Form1 : Form
    {
        public string printePort { get; set; } = "";
        IntPtr printer;
        public Form1()
        {
            InitializeComponent();
            GetComPort();
            printer = CPCLPrint.InitPrinter("");
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
        int openStatus = 100;
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
                CPCLPrint.ClosePort(printer);
            }
            switch (portflag)
            {
                case 0:
                    openStatus = CPCLPrint.OpenPort(printer, "USB,");
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
                    openStatus = CPCLPrint.OpenPort(printer, $"{cb_COMName.Text},{cb_BaudRate.Text}");
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
                    openStatus = CPCLPrint.OpenPort(printer, $"NET,{tb_IP.Text}");
                    if (openStatus != 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Fail to open NET port, please check!" + "\r\n";
                    }
                    else
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Connect secceed!" + "\r\n";
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
                        CPCLPrint.ClosePort(printer);
                        PortOeen();
                        openStatus = 100;
                    }
                    break;
                case 1:
                    if (openStatus == 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "COM port closed!" + "\r\n";
                        CPCLPrint.ClosePort(printer);
                        PortOeen();
                        openStatus = 100;
                    }
                    break;
                case 2:
                    if (openStatus == 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "NET port closed!" + "\r\n";
                        CPCLPrint.ClosePort(printer);
                        PortOeen();
                        openStatus = 100;
                    }
                    break;
            }
        }

        private void btn_Text_Click(object sender, EventArgs e)
        {
            try
            {
                if (openStatus != 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                    return;
                }
                CPCLPrint.CPCL_AddLabel(printer, 0, 240, 1);
                CPCLPrint.CPCL_SetAlign(printer, 0);
                CPCLPrint.CPCL_AddText(printer, 0, "4", 7, 20, 60, "Welcome to the world of printing!");
                CPCLPrint.CPCL_Print(printer);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btn_Barcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (openStatus != 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                    return;
                }
                CPCLPrint.CPCL_AddLabel(printer, 0, 240, 1);
                CPCLPrint.CPCL_SetAlign(printer, 0);
                CPCLPrint.CPCL_AddBarCodeText(printer, 1, 7, 0, 0);
                CPCLPrint.CPCL_AddBarCode(printer, 0, 20, 1, 1, 80, 20, 60, "123456789");
                CPCLPrint.CPCL_Print(printer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btn_Qrcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (openStatus != 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                    return;
                }
                CPCLPrint.CPCL_AddLabel(printer, 0, 240, 1);
                CPCLPrint.CPCL_SetAlign(printer, 0);
                CPCLPrint.CPCL_AddQRCode(printer, 0, 20, 60, 2, 6, 0, "ABCDEFG..0123456789@#%^&*()");
                CPCLPrint.CPCL_Print(printer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btn_TextUnderline_Click(object sender, EventArgs e)
        {
            try
            {
                if (openStatus != 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                    return;
                }
                CPCLPrint.CPCL_AddLabel(printer, 0, 240, 1);
                CPCLPrint.CPCL_SetAlign(printer, 0);
                CPCLPrint.CPCL_SetTextUnderline(printer, 4);
                CPCLPrint.CPCL_AddText(printer, 0, "4", 7, 20, 60, "Welcome to the world of printing!");
                CPCLPrint.CPCL_Print(printer);
            }
            catch (Exception)
            {
                throw;
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
                CPCLPrint.CPCL_AddLabel(printer, 0, 240, 1);
                CPCLPrint.CPCL_SetAlign(printer, 0);
                CPCLPrint.CPCL_AddPDF417(printer, 0, 40, 60, 3, 12, 3, 2, "ASDFGH12345678");
                int result = CPCLPrint.CPCL_Print(printer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_Bar_Click(object sender, EventArgs e)
        {
            try
            {
                if (openStatus != 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                    return;
                }
                CPCLPrint.CPCL_AddLabel(printer, 0, 240, 1);
                CPCLPrint.CPCL_SetAlign(printer, 0);
                CPCLPrint.CPCL_AddLine(printer, 40, 80, 200, 80, 5);
                CPCLPrint.CPCL_Print(printer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_Box_Click(object sender, EventArgs e)
        {
            try
            {
                if (openStatus != 0)
                {
                    tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                    return;
                }
                CPCLPrint.CPCL_AddLabel(printer, 0, 240, 1);
                CPCLPrint.CPCL_SetAlign(printer, 0);
                CPCLPrint.CPCL_AddBox(printer, 40, 60, 400, 150, 5);
                CPCLPrint.CPCL_Print(printer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_BitMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files(*.*)|*.*";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory.ToString();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (openStatus != 0)
                    {
                        tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                        return;
                    }
                    CPCLPrint.CPCL_AddLabel(printer, 0, 240, 1);
                    CPCLPrint.CPCL_SetAlign(printer, 0);
                    CPCLPrint.CPCL_AddImage(printer, 0, 40, 20, openFileDialog1.FileName);
                    CPCLPrint.CPCL_Print(printer);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            CPCLPrint.ReleasePrinter(printer);
        }

        private void tb_Msg_TextChanged(object sender, EventArgs e)
        {
            tb_Msg.SelectionStart = tb_Msg.TextLength;
            tb_Msg.ScrollToCaret();
        }

        private void printer_status_Click(object sender, EventArgs e)
        {
            if (openStatus != 0)
            {
                tb_Msg.Text += DateTime.Now.ToString("G") + " : " + "Please connect the printer first!\r\n";
                return;
            }
            int ret = CPCLPrint.CPCL_GetPrinterStatus(printer, out int status);
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
    }
}
