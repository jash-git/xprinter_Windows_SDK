


#include "pch.h"
#include "framework.h"
#include "CPCL_Demo.h"
#include "CPCL_DemoDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif
CUIntArray ports, portse, portsu;
int ret = 100;
CString text, date;





CCPCLDemoDlg::CCPCLDemoDlg(CWnd* pParent /*=nullptr*/)
	: CDialog(IDD_CPCL_DEMO_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CCPCLDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_RADIO_USB, m_radioUsb);
	DDX_Control(pDX, IDC_RADIO_COM, m_radioCom);
	DDX_Control(pDX, IDC_RADIO_NET, m_radioNet);
	DDX_Control(pDX, IDC_EDIT_MSG, m_msg);
	DDX_Control(pDX, IDC_EDIT_NET, m_editHost);
	DDX_Control(pDX, IDC_COMBO_COM_PORT_NAME, m_comboComPortName);
	DDX_Control(pDX, IDC_COMBO_BAUDRATE, m_comboBaudrate);
}

BEGIN_MESSAGE_MAP(CCPCLDemoDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON_OPEN, &CCPCLDemoDlg::OnClickedButtonOpen)
	ON_BN_CLICKED(IDC_RADIO_USB, &CCPCLDemoDlg::OnClickedRadioUsb)
	ON_BN_CLICKED(IDC_RADIO_NET, &CCPCLDemoDlg::OnClickedRadioNet)
	ON_BN_CLICKED(IDC_RADIO_COM, &CCPCLDemoDlg::OnClickedRadioCom)
	ON_BN_CLICKED(IDC_BUTTON_CLOSE, &CCPCLDemoDlg::OnClickedButtonClose)
	ON_BN_CLICKED(IDC_BUTTON_TEXT, &CCPCLDemoDlg::OnClickedButtonText)
	ON_BN_CLICKED(IDC_BUTTON_BARCODE, &CCPCLDemoDlg::OnClickedButtonBarcode)
	ON_BN_CLICKED(IDC_BUTTON_QRCODE, &CCPCLDemoDlg::OnClickedButtonQrcode)
	ON_BN_CLICKED(IDC_BUTTON_PDF417, &CCPCLDemoDlg::OnClickedButtonPdf417)
	ON_BN_CLICKED(IDC_BUTTON_LINE, &CCPCLDemoDlg::OnClickedButtonLine)
	ON_BN_CLICKED(IDC_BUTTON_BOX, &CCPCLDemoDlg::OnClickedButtonBox)
	ON_BN_CLICKED(IDC_BUTTON_BITMAP, &CCPCLDemoDlg::OnClickedButtonBitmap)
	ON_WM_CLOSE()
	ON_BN_CLICKED(IDC_BUTTON_TEXTUNDERLINE, &CCPCLDemoDlg::OnClickedButtonTextunderline)
	ON_BN_CLICKED(IDC_PRINTER_STATUS, &CCPCLDemoDlg::OnBnClickedPrinterStatus)
END_MESSAGE_MAP()



BOOL CCPCLDemoDlg::OnInitDialog()
{
	CDialog::OnInitDialog();


	SetIcon(m_hIcon, TRUE);
	SetIcon(m_hIcon, FALSE);


	m_radioUsb.SetCheck(BST_CHECKED);

	m_comboBaudrate.InsertString(-1, _T("9600"));
	m_comboBaudrate.InsertString(-1, _T("19200"));
	m_comboBaudrate.InsertString(-1, _T("38400"));
	m_comboBaudrate.InsertString(-1, _T("57600"));
	m_comboBaudrate.InsertString(-1, _T("115200"));


	hDllInst = ::LoadLibrary(_T("printer.sdk.dll"));
	if (hDllInst)
	{
		InitPrinter = (pInitPrinter)GetProcAddress(hDllInst, "InitPrinter");
		OpenPort = (pOpenPort)GetProcAddress(hDllInst, "OpenPort");
		ClosePort = (pClosePort)GetProcAddress(hDllInst, "ClosePort");
		ReleasePrinter = (pReleasePrinter)GetProcAddress(hDllInst, "ReleasePrinter");
		WriteData = (pWriteData)GetProcAddress(hDllInst, "WriteData");
		ReadData = (pReadData)GetProcAddress(hDllInst, "ReadData");
		CPCL_AddLabel = (pCPCL_AddLabel)GetProcAddress(hDllInst, "CPCL_AddLabel");
		CPCL_SetAlign = (pCPCL_SetAlign)GetProcAddress(hDllInst, "CPCL_SetAlign");
		CPCL_AddText = (pCPCL_AddText)GetProcAddress(hDllInst, "CPCL_AddText");
		CPCL_AddBarCode = (pCPCL_AddBarCode)GetProcAddress(hDllInst, "CPCL_AddBarCode");
		CPCL_AddBarCodeText = (pCPCL_AddBarCodeText)GetProcAddress(hDllInst, "CPCL_AddBarCodeText");
		CPCL_AddQRCode = (pCPCL_AddQRCode)GetProcAddress(hDllInst, "CPCL_AddQRCode");
		CPCL_AddPDF417 = (pCPCL_AddPDF417)GetProcAddress(hDllInst, "CPCL_AddPDF417");
		CPCL_AddBox = (pCPCL_AddBox)GetProcAddress(hDllInst, "CPCL_AddBox");
		CPCL_AddLine = (pCPCL_AddLine)GetProcAddress(hDllInst, "CPCL_AddLine");
		CPCL_AddImage = (pCPCL_AddImage)GetProcAddress(hDllInst, "CPCL_AddImage");
		CPCL_SetTextUnderline = (pCPCL_SetTextUnderline)GetProcAddress(hDllInst, "CPCL_SetTextUnderline");
		CPCL_Print = (pCPCL_Print)GetProcAddress(hDllInst, "CPCL_Print");
		CPCL_GetPrinterStatus = (pCPCL_GetPrinterStatus)GetProcAddress(hDllInst, "CPCL_GetPrinterStatus");

	}
	else
	{
		AfxMessageBox(_T("Failed to load the dynamic library. Procedure printer.sdk.dll"));
	}


	AddCom();
	EnableBtn(false);

	return TRUE;
}


void CCPCLDemoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this);

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);


		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;


		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}
void CCPCLDemoDlg::GetComList(CUIntArray& ports, CUIntArray& portse, CUIntArray& portsu)
{
	ports.RemoveAll();
	for (int i = 1; i < 256; i++)
	{
		CString sPort;
		sPort.Format(_T("\\\\.\\COM%d"), i);
		BOOL bSuccess = FALSE;
		HANDLE hPort = ::CreateFile(sPort, GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);
		if (hPort == INVALID_HANDLE_VALUE)
		{
			DWORD dwError = GetLastError();

			if (dwError == ERROR_ACCESS_DENIED)
			{
				bSuccess = TRUE;
				portsu.Add(i);
			}
		}
		else
		{
			bSuccess = TRUE;
			portse.Add(i);
			CloseHandle(hPort);
		}
		if (bSuccess)
			ports.Add(i);
	}
}
void CCPCLDemoDlg::AddCom(void)
{
	GetComList(ports, portse, portsu);
	unsigned short uicounter;
	unsigned short uisetcom;
	CString str;
	uicounter = portse.GetSize();
	if (uicounter > 0)
	{
		for (int i = 0; i < uicounter; i++)
		{
			uisetcom = portse.ElementAt(i);
			str.Format(_T("COM%d"), uisetcom);
			m_comboComPortName.AddString(str);
		}
	}
}

void CCPCLDemoDlg::SetMsg(CString r)
{
	currentTime = CTime::GetCurrentTime();
	date = currentTime.Format(_T("%Y-%m-%d %H:%M:%S"));
	msg += date + r + _T("\r\n");
	m_msg.SetWindowTextW(msg);
	m_msg.LineScroll(m_msg.GetLineCount() - 1, 0);
}





HCURSOR CCPCLDemoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CCPCLDemoDlg::OnClickedButtonOpen()
{
	if (printer)
	{
		ReleasePrinter(printer);
	}
	printer = InitPrinter(L"");
	if (portflag == 0)
	{
		ret = OpenPort(printer, L"USB,");
		if (ret == 0)
		{
			text = _T(" : USB port opened!");
			SetMsg(text);
			EnableBtn(true);
		}
		else
		{
			text = _T(" : Fail to open USB port, please check!");
			SetMsg(text);
		}
	}
	else if (portflag == 1)
	{
		CString baudrateStr, portName;
		m_comboBaudrate.GetWindowText(baudrateStr);
		m_comboComPortName.GetWindowText(portName);

		wchar_t buffer[100] = { 0 };
		const wchar_t* baudrateW = static_cast<const wchar_t*>(baudrateStr);
		const wchar_t* portW = static_cast<const wchar_t*>(portName);
		swprintf_s(buffer, 100, L"%s,%s", portW, baudrateW);
		ret = OpenPort(printer, buffer);
		if (ret == 0)
		{
			text = _T(" : COM port opened!");
			SetMsg(text);
			EnableBtn(true);
		}
		else
		{
			text = _T(" : Fail to open COM port, please check!");
			SetMsg(text);
		};
	}
	else if (portflag == 2)
	{
		CString host;
		m_editHost.GetWindowText(host);
		host.Trim();
		wchar_t buffer[100] = { 0 };
		swprintf_s(buffer, 100, L"NET,%s", host.AllocSysString());
		ret = OpenPort(printer, buffer);
		if (ret == 0)
		{
			text = _T(" : NET port connect secceed!");
			SetMsg(text);
			EnableBtn(true);
		}
		else
		{
			text = _T(" : Fail to open NET port, please check!");
			SetMsg(text);
		}
	}
}


void CCPCLDemoDlg::OnClickedButtonClose()
{
	if (portflag == 0)
	{
		if (ret == 0)
		{
			text = _T(" : USB port closed!");
			SetMsg(text);
			ClosePort(printer);
			EnableBtn(false);
			ret = 100;
		}
	}
	else if (portflag == 1)
	{
		if (ret == 0)
		{
			text = _T(" : COM port closed!");
			SetMsg(text);
			ClosePort(printer);
			EnableBtn(false);
			ret = 100;
		}
	}
	else if (portflag == 2)
	{
		if (ret == 0)
		{
			text = _T(" : NET port closed!");
			SetMsg(text);
			ClosePort(printer);
			EnableBtn(false);
			ret = 100;
		}
	}
}

void CCPCLDemoDlg::OnClickedRadioUsb()
{
	m_radioUsb.SetCheck(BST_CHECKED);
	m_radioCom.SetCheck(BST_UNCHECKED);
	m_radioNet.SetCheck(BST_UNCHECKED);
	portflag = 0;
}


void CCPCLDemoDlg::OnClickedRadioCom()
{
	m_radioUsb.SetCheck(BST_UNCHECKED);
	m_radioCom.SetCheck(BST_CHECKED);
	m_radioNet.SetCheck(BST_UNCHECKED);
	portflag = 1;

}


void CCPCLDemoDlg::OnClickedRadioNet()
{
	m_radioUsb.SetCheck(BST_UNCHECKED);
	m_radioCom.SetCheck(BST_UNCHECKED);
	m_radioNet.SetCheck(BST_CHECKED);
	portflag = 2;

}

void CCPCLDemoDlg::EnableBtn(bool e)
{
	//IDC_BUTTON1
	((CButton*)GetDlgItem(IDC_BUTTON_TEXT))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_BARCODE))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_TEXTUNDERLINE))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_QRCODE))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_BOX))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_BITMAP))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_PDF417))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_LINE))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_CLOSE))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_PRINTER_STATUS))->EnableWindow(e);

}

void CCPCLDemoDlg::OnClickedButtonText()
{
	if (ret == 0)
	{
		CPCL_AddLabel(printer, 0, 240, 1);
		CPCL_SetAlign(printer, 0);
		CPCL_AddText(printer, 0, "4", 7, 20, 60, L"Welcome to the world of printing!");
		int result = CPCL_Print(printer);
		if (result == 0)
		{
			text = _T(" : Print text secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CCPCLDemoDlg::OnClickedButtonBarcode()
{
	if (ret == 0)
	{
		CPCL_AddLabel(printer, 0, 240, 1);
		CPCL_SetAlign(printer, 0);
		CPCL_AddBarCodeText(printer, 1, 7, 0, 0);
		CPCL_AddBarCode(printer, 0, 20, 1, 1, 80, 20, 60, L"123456789");
		int result = CPCL_Print(printer);
		if (result == 0)
		{
			text = _T(" : Print barcode secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CCPCLDemoDlg::OnClickedButtonQrcode()
{
	if (ret == 0)
	{
		CPCL_AddLabel(printer, 0, 240, 1);
		CPCL_SetAlign(printer, 0);
		CPCL_AddQRCode(printer, 0, 20, 60, 2, 6, 0, L"ABCDEFG..0123456789@#%^&*()");
		int result = CPCL_Print(printer);
		if (result == 0)
		{
			text = _T(" : Print Qrcode secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}

}


void CCPCLDemoDlg::OnClickedButtonPdf417()
{
	if (ret == 0)
	{
		CPCL_AddLabel(printer, 0, 240, 1);
		CPCL_SetAlign(printer, 0);
		CPCL_AddPDF417(printer, 0, 40, 60, 3, 12, 3, 2, L"ASDFGH12345678");
		int result = CPCL_Print(printer);
		if (result == 0)
		{
			text = _T(" : Print Pdf417 secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CCPCLDemoDlg::OnClickedButtonLine()
{
	if (ret == 0)
	{
		CPCL_AddLabel(printer, 0, 240, 1);
		CPCL_SetAlign(printer, 0);
		CPCL_AddLine(printer, 40, 80, 200, 80, 5);
		int result = CPCL_Print(printer);
		if (result == 0)
		{
			text = _T(" : Print Line secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CCPCLDemoDlg::OnClickedButtonBox()
{
	if (ret == 0)
	{
		CPCL_AddLabel(printer, 0, 240, 1);
		CPCL_SetAlign(printer, 0);
		CPCL_AddBox(printer, 40, 40, 400, 150, 5);
		int result = CPCL_Print(printer);
		if (result == 0)
		{
			text = _T(" : Print Box secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CCPCLDemoDlg::OnClickedButtonBitmap()
{
	if (ret == 0)
	{
		TCHAR tpath[MAX_PATH];
		CFileDialog BmpFileDlg(TRUE);
		BmpFileDlg.m_ofn.lpstrInitialDir = tpath;
		BmpFileDlg.m_ofn.lpstrFilter = _T("Image Files\0*.jpg;*.jpeg;*.png;*.bmp\0All Files\0*.*\0");
		if (IDOK == BmpFileDlg.DoModal())
		{
			CString strBmpFilePath = BmpFileDlg.GetPathName();
			USES_CONVERSION;
			CPCL_AddLabel(printer, 0, 240, 1);
			CPCL_SetAlign(printer, 0);
			CPCL_AddImage(printer, 0, 40, 0, strBmpFilePath);
			int result = CPCL_Print(printer);
			if (result == 0)
			{
				text = _T(" : Print image secceed!");
				SetMsg(text);
			}
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CCPCLDemoDlg::OnClose()
{
	ReleasePrinter(printer);
	CDialog::OnClose();
}


void CCPCLDemoDlg::OnClickedButtonTextunderline()
{
	if (ret == 0)
	{
		CPCL_AddLabel(printer, 0, 240, 1);
		CPCL_SetTextUnderline(printer, 1);
		CPCL_AddText(printer, 0, "4", 7, 20, 60, L"Welcome to the world of printing!");
		int result = CPCL_Print(printer);
		if (result == 0)
		{
			text = _T(" : Print UnderlineLine secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CCPCLDemoDlg::OnBnClickedPrinterStatus()
{
	int status;
	if (ret == 0)
	{
		int  rValue = CPCL_GetPrinterStatus(printer, &status);
		if (rValue == 0)
		{
			if (status == 0)
			{
				text = _T(" : Printer normal!");
			}
			else if ((status & 0b1) > 0)
			{
				text = _T(" : The print head is opened！");
			}
			else if ((status & 0b10) > 0)
			{
				text = _T(" : Paper jam！");
			}
			else if ((status & 0b100) > 0)
			{
				text = _T(" : Out of paper！");
			}
			else if ((status & 0b1000) > 0)
			{
				text = _T(" : Out of ribbon！");
			}
			else if ((status & 0b10000) > 0)
			{
				text = _T(" : Print pause！");
			}
			else if ((status & 0b100000) > 0)
			{
				text = _T(" : Printing！");
			}
			else if ((status & 0b1000000) > 0)
			{
				text = _T(" : Cover opened！");
			}
			else
			{
				text = _T(" : Other error！");
			}
		}
		else {
			text = _T(" : Read error！");
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
	}
	SetMsg(text);
}
