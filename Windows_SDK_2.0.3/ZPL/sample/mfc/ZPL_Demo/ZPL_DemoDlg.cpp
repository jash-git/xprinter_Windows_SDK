


#include "pch.h"
#include "framework.h"
#include "ZPL_Demo.h"
#include "ZPL_DemoDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

CUIntArray ports, portse, portsu;
int ret = 100;
CString text, date;


CZPLDemoDlg::CZPLDemoDlg(CWnd* pParent /*=nullptr*/)
	: CDialog(IDD_ZPL_DEMO_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CZPLDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EDIT_MSG, m_msg);
	DDX_Control(pDX, IDC_RADIO_USB, m_radioUsb);
	DDX_Control(pDX, IDC_RADIO_COM, m_radioCom);
	DDX_Control(pDX, IDC_RADIO_NET, m_radioNet);
	DDX_Control(pDX, IDC_COMBO_BAUDRATE, m_comboBaudrate);
	DDX_Control(pDX, IDC_COMBO_COM_PORT_NAME, m_comboComPortName);
	DDX_Control(pDX, IDC_EDIT_NET, m_editHost);
	DDX_Control(pDX, IDC_BUTTON_TEXT, m_priText);

}

BEGIN_MESSAGE_MAP(CZPLDemoDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON_OPEN, &CZPLDemoDlg::OnClickedButtonOpen)
	ON_BN_CLICKED(IDC_BUTTON_CLOSE, &CZPLDemoDlg::OnClickedButtonClose)
	ON_BN_CLICKED(IDC_RADIO_USB, &CZPLDemoDlg::OnClickedRadioUsb)
	ON_BN_CLICKED(IDC_RADIO_COM, &CZPLDemoDlg::OnClickedRadioCom)
	ON_BN_CLICKED(IDC_RADIO_NET, &CZPLDemoDlg::OnClickedRadioNet)
	ON_WM_CLOSE()
	ON_BN_CLICKED(IDC_BUTTON_TEXT, &CZPLDemoDlg::OnClickedButtonText)
	ON_BN_CLICKED(IDC_BUTTON_BARCODE, &CZPLDemoDlg::OnClickedButtonBarcode)
	ON_BN_CLICKED(IDC_BUTTON_DATAMATRIX, &CZPLDemoDlg::OnClickedButtonDatamatrix)
	ON_BN_CLICKED(IDC_BUTTON_QRCODE, &CZPLDemoDlg::OnClickedButtonQrcode)
	ON_BN_CLICKED(IDC_BUTTON_BOX, &CZPLDemoDlg::OnClickedButtonBox)
	ON_BN_CLICKED(IDC_BUTTON_BITMAP, &CZPLDemoDlg::OnClickedButtonBitmap)
	ON_BN_CLICKED(IDC_BUTTON_PDF417, &CZPLDemoDlg::OnClickedButtonPdf417)
	ON_BN_CLICKED(IDC_BUTTON_PRINTCONFIG, &CZPLDemoDlg::OnClickedButtonPrintconfig)
	ON_BN_CLICKED(IDC_BUTTON_PRINTSTATUS, &CZPLDemoDlg::OnClickedButtonPrintstatus)
	ON_BN_CLICKED(IDC_BUTTON_TEXTBLOCK, &CZPLDemoDlg::OnClickedButtonTextblock)
END_MESSAGE_MAP()



BOOL CZPLDemoDlg::OnInitDialog()
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
		ZPL_StartFormat = (pZPL_StartFormat)GetProcAddress(hDllInst, "ZPL_StartFormat");
		ZPL_EndFormat = (pZPL_EndFormat)GetProcAddress(hDllInst, "ZPL_EndFormat");
		ZPL_Text = (pZPL_Text)GetProcAddress(hDllInst, "ZPL_Text");
		ZPL_BarCode128 = (pZPL_BarCode128)GetProcAddress(hDllInst, "ZPL_BarCode128");
		ZPL_QRCode = (pZPL_QRCode)GetProcAddress(hDllInst, "ZPL_QRCode");
		ZPL_GraphicBox = (pZPL_GraphicBox)GetProcAddress(hDllInst, "ZPL_GraphicBox");
		ZPL_PrintImage = (pZPL_PrintImage)GetProcAddress(hDllInst, "ZPL_PrintImage");
		ZPL_DataMatrixBarcode = (pZPL_DataMatrixBarcode)GetProcAddress(hDllInst, "ZPL_DataMatrixBarcode");
		ZPL_Text_Block = (pZPL_Text_Block)GetProcAddress(hDllInst, "ZPL_Text_Block");
		ZPL_GetPrinterStatus = (pZPL_GetPrinterStatus)GetProcAddress(hDllInst, "ZPL_GetPrinterStatus");
		ZPL_PrintConfigurationLabel = (pZPL_PrintConfigurationLabel)GetProcAddress(hDllInst, "ZPL_PrintConfigurationLabel");
		ZPL_Pdf417 = (pZPL_Pdf417)GetProcAddress(hDllInst, "ZPL_Pdf417");
	}
	else
	{
		AfxMessageBox(_T("Failed to load the dynamic library. Procedure printer.sdk.dll"));
	}

	AddCom();
	EnableBtn(false);


	return TRUE;
}


void CZPLDemoDlg::OnPaint()
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

HCURSOR CZPLDemoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CZPLDemoDlg::OnClickedButtonOpen()
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


void CZPLDemoDlg::OnClickedButtonClose()
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

void CZPLDemoDlg::OnClickedRadioUsb()
{
	m_radioUsb.SetCheck(BST_CHECKED);
	m_radioCom.SetCheck(BST_UNCHECKED);
	m_radioNet.SetCheck(BST_UNCHECKED);
	portflag = 0;
}


void CZPLDemoDlg::OnClickedRadioCom()
{
	m_radioUsb.SetCheck(BST_UNCHECKED);
	m_radioCom.SetCheck(BST_CHECKED);
	m_radioNet.SetCheck(BST_UNCHECKED);
	portflag = 1;

}


void CZPLDemoDlg::OnClickedRadioNet()
{
	m_radioUsb.SetCheck(BST_UNCHECKED);
	m_radioCom.SetCheck(BST_UNCHECKED);
	m_radioNet.SetCheck(BST_CHECKED);
	portflag = 2;

}
void CZPLDemoDlg::EnableBtn(bool e)
{
	//IDC_BUTTON1
	((CButton*)GetDlgItem(IDC_BUTTON_TEXT))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_BARCODE))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_DATAMATRIX))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_QRCODE))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_BOX))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_BITMAP))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_PDF417))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_PRINTSTATUS))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_CLOSE))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_TEXTBLOCK))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_PRINTCONFIG))->EnableWindow(e);

}
void CZPLDemoDlg::GetComList(CUIntArray& ports, CUIntArray& portse, CUIntArray& portsu)
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
void CZPLDemoDlg::AddCom(void)
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


void CZPLDemoDlg::OnClose()
{
	ReleasePrinter(printer);
	CDialog::OnClose();
}


void CZPLDemoDlg::OnClickedButtonText()
{
	if (ret == 0)
	{
		ZPL_StartFormat(printer);
		ZPL_Text(printer, 120, 20, 12, 0, 15, 12, L"Print text secceed!");
		ZPL_EndFormat(printer);
		text = _T(" : Print text secceed!");
		SetMsg(text);
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}
void CZPLDemoDlg::SetMsg(CString r)
{
	currentTime = CTime::GetCurrentTime();
	date = currentTime.Format(_T("%Y-%m-%d %H:%M:%S"));
	msg += date + r + _T("\r\n");
	m_msg.SetWindowTextW(msg);
	m_msg.LineScroll(m_msg.GetLineCount() - 1, 0);
}

void CZPLDemoDlg::OnClickedButtonBarcode()
{
	if (ret == 0)
	{
		ZPL_StartFormat(printer);
		ZPL_BarCode128(printer, 120, 10, 0, 3, 80, 'Y', 'N', 'N', 'A', L"123456");
		ZPL_EndFormat(printer);
		text = _T(" : Print text secceed!");
		SetMsg(text);
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CZPLDemoDlg::OnClickedButtonDatamatrix()
{
	if (ret == 0)
	{
		ZPL_StartFormat(printer);
		ZPL_DataMatrixBarcode(printer, 120, 10, 0, 8, 100, 5, 4, 5, 1, L"ABCDEFG1235ABCDEFG1235!@#$%^&");
		ZPL_EndFormat(printer);
		text = _T(" : Print DataMatrix secceed!");
		SetMsg(text);
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}

}


void CZPLDemoDlg::OnClickedButtonQrcode()
{
	if (ret == 0)
	{
		ZPL_StartFormat(printer);
		ZPL_QRCode(printer, 120, 5, 0, 2, 5, 'Q', '0', 'B', L"Welcome to the world of printing!");
		ZPL_EndFormat(printer);
		text = _T(" : Print Qrcode secceed!");
		SetMsg(text);
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CZPLDemoDlg::OnClickedButtonBox()
{
	if (ret == 0)
	{
		ZPL_StartFormat(printer);
		ZPL_GraphicBox(printer, 120, 10, 400, 150, 5, 0);
		ZPL_EndFormat(printer);
		text = _T(" : Print Box secceed!");
		SetMsg(text);
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CZPLDemoDlg::OnClickedButtonBitmap()
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
			ZPL_StartFormat(printer);
			ZPL_PrintImage(printer, 120, 10, strBmpFilePath);
			ZPL_EndFormat(printer);
			text = _T(" : Print BitMap secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}

}


void CZPLDemoDlg::OnClickedButtonPdf417()
{
	if (ret == 0)
	{
		ZPL_StartFormat(printer);
		ZPL_Pdf417(printer, 120, 10, 0, 4, 5, 3, 3, 20, 'N', L"ASDFGH12345678");
		ZPL_EndFormat(printer);
		text = _T(" : Print Pdf417 secceed!");
		SetMsg(text);
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CZPLDemoDlg::OnClickedButtonPrintconfig()
{
	if (ret == 0)
	{
		ZPL_StartFormat(printer);
		ZPL_PrintConfigurationLabel(printer);
		ZPL_EndFormat(printer);
		text = _T(" : Print Configuration secceed!");
		SetMsg(text);
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}


void CZPLDemoDlg::OnClickedButtonPrintstatus()
{
	int status;
	if (ret == 0)
	{
		int  rValue = ZPL_GetPrinterStatus(printer, &status);
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


void CZPLDemoDlg::OnClickedButtonTextblock()
{
	if (ret == 0)
	{
		ZPL_StartFormat(printer);
		ZPL_Text_Block(printer, 120, 20, 14, 0, 15, 12, 400, 200, L"Welcome to the world of printing!");
		ZPL_EndFormat(printer);
		text = _T(" : Print TextBlock secceed!");
		SetMsg(text);
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}
