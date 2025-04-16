

#include "pch.h"
#include "framework.h"
#include "TSPL_Demo.h"
#include "TSPL_DemoDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

CUIntArray ports, portse, portsu;
int ret = 100;
CString text, date;

CTSPLDemoDlg::CTSPLDemoDlg(CWnd* pParent /*=nullptr*/)
	: CDialog(IDD_TSPL_DEMO_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CTSPLDemoDlg::DoDataExchange(CDataExchange* pDX)
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

BEGIN_MESSAGE_MAP(CTSPLDemoDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON_OPEN, &CTSPLDemoDlg::OnClickedButtonOpen)
	ON_BN_CLICKED(IDC_BUTTON_CLOSE, &CTSPLDemoDlg::OnClickedButtonClose)
	ON_BN_CLICKED(IDC_RADIO_USB, &CTSPLDemoDlg::OnClickedRadioUsb)
	ON_BN_CLICKED(IDC_RADIO_COM, &CTSPLDemoDlg::OnClickedRadioCom)
	ON_BN_CLICKED(IDC_RADIO_NET, &CTSPLDemoDlg::OnClickedRadioNet)
	ON_BN_CLICKED(IDC_BUTTON_TEXT, &CTSPLDemoDlg::OnClickedButtonText)
	ON_BN_CLICKED(IDC_BUTTON_BARCODE, &CTSPLDemoDlg::OnClickedButtonBarcode)
	ON_BN_CLICKED(IDC_BUTTON_QRCODE, &CTSPLDemoDlg::OnClickedButtonQrcode)
	ON_BN_CLICKED(IDC_BUTTON_BAR, &CTSPLDemoDlg::OnClickedButtonBar)
	ON_BN_CLICKED(IDC_BUTTON_DATAMATRIX, &CTSPLDemoDlg::OnClickedButtonDatamatrix)
	ON_BN_CLICKED(IDC_BUTTON_BOX, &CTSPLDemoDlg::OnClickedButtonBox)
	ON_BN_CLICKED(IDC_BUTTON_BITMAP, &CTSPLDemoDlg::OnClickedButtonBitmap)
	ON_BN_CLICKED(IDC_BUTTON_PDF417, &CTSPLDemoDlg::OnClickedButtonPdf417)
	ON_BN_CLICKED(IDC_BUTTON_PRINTSTATUS, &CTSPLDemoDlg::OnClickedButtonPrintstatus)
	ON_BN_CLICKED(IDC_BUTTON_TEXTBLOCK, &CTSPLDemoDlg::OnClickedButtonTextblock)
END_MESSAGE_MAP()

BOOL CTSPLDemoDlg::OnInitDialog()
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
		TSPL_Text = (pTSPL_Text)GetProcAddress(hDllInst, "TSPL_Text");
		TSPL_Print = (pTSPL_Print)GetProcAddress(hDllInst, "TSPL_Print");
		TSPL_Bar = (pTSPL_Bar)GetProcAddress(hDllInst, "TSPL_Bar");
		TSPL_BarCode = (pTSPL_BarCode)GetProcAddress(hDllInst, "TSPL_BarCode");
		TSPL_Image = (pTSPL_Image)GetProcAddress(hDllInst, "TSPL_Image");
		TSPL_Setup = (pTSPL_Setup)GetProcAddress(hDllInst, "TSPL_Setup");
		TSPL_ClearBuffer = (pTSPL_ClearBuffer)GetProcAddress(hDllInst, "TSPL_ClearBuffer");
		TSPL_Box = (pTSPL_Box)GetProcAddress(hDllInst, "TSPL_Box");
		TSPL_QrCode = (pTSPL_QrCode)GetProcAddress(hDllInst, "TSPL_QrCode");
		TSPL_Home = (pTSPL_Home)GetProcAddress(hDllInst, "TSPL_Home");
		TSPL_GetPrinterStatus = (pTSPL_GetPrinterStatus)GetProcAddress(hDllInst, "TSPL_GetPrinterStatus");
		TSPL_PDF417 = (pTSPL_PDF417)GetProcAddress(hDllInst, "TSPL_PDF417");
		TSPL_Block = (pTSPL_Block)GetProcAddress(hDllInst, "TSPL_Block");
		TSPL_Dmatrix = (pTSPL_Dmatrix)GetProcAddress(hDllInst, "TSPL_Dmatrix");
	}
	else
	{
		AfxMessageBox(_T("Failed to load the dynamic library. Procedure printer.sdk.dll"));
	}

	AddCom();
	EnableBtn(false);

	return TRUE;
}

void CTSPLDemoDlg::OnPaint()
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

HCURSOR CTSPLDemoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CTSPLDemoDlg::OnClickedButtonOpen()
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


void CTSPLDemoDlg::OnClickedButtonClose()
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

void CTSPLDemoDlg::OnClickedRadioUsb()
{
	m_radioUsb.SetCheck(BST_CHECKED);
	m_radioCom.SetCheck(BST_UNCHECKED);
	m_radioNet.SetCheck(BST_UNCHECKED);
	portflag = 0;
}


void CTSPLDemoDlg::OnClickedRadioCom()
{
	m_radioUsb.SetCheck(BST_UNCHECKED);
	m_radioCom.SetCheck(BST_CHECKED);
	m_radioNet.SetCheck(BST_UNCHECKED);
	portflag = 1;

}


void CTSPLDemoDlg::OnClickedRadioNet()
{
	m_radioUsb.SetCheck(BST_UNCHECKED);
	m_radioCom.SetCheck(BST_UNCHECKED);
	m_radioNet.SetCheck(BST_CHECKED);
	portflag = 2;

}
void CTSPLDemoDlg::EnableBtn(bool e)
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
void CTSPLDemoDlg::GetComList(CUIntArray& ports, CUIntArray& portse, CUIntArray& portsu)
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
void CTSPLDemoDlg::AddCom(void)
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
void CTSPLDemoDlg::SetMsg(CString r)
{
	currentTime = CTime::GetCurrentTime();
	date = currentTime.Format(_T("%Y-%m-%d %H:%M:%S"));
	msg += date + r + _T("\r\n");
	m_msg.SetWindowTextW(msg);
	m_msg.LineScroll(m_msg.GetLineCount() - 1, 0);
}

void CTSPLDemoDlg::OnClickedButtonText()
{
	if (ret == 0)
	{
		TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
		TSPL_ClearBuffer(printer);
		TSPL_Text(printer, 80, 70, "3", "TEST", 0, 2, 2, 0);
		TSPL_Text(printer, 50, 150, "2", "Welcome to the world of printing!", 0, 1, 1, 0);
		int result = TSPL_Print(printer, 1, 1);
		if (result == 0)
		{
			text = _T(" : Print Text secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}

void CTSPLDemoDlg::OnClickedButtonBarcode()
{
	if (ret == 0)
	{
		TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
		TSPL_ClearBuffer(printer);
		TSPL_BarCode(printer, 60, 60, 0, "123abcd", 80, 0, 0, 2, 2);
		int result = TSPL_Print(printer, 1, 1);
		if (result == 0)
		{
			text = _T(" : Print Barcode secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}

void CTSPLDemoDlg::OnClickedButtonQrcode()
{
	if (ret == 0)
	{
		TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
		TSPL_ClearBuffer(printer);
		TSPL_QrCode(printer, 60, 50, 7, 1, 1, 0, 1, 2, "TESTCODE1234");
		int result = TSPL_Print(printer, 1, 1);
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

void CTSPLDemoDlg::OnClickedButtonBar()
{
	if (ret == 0)
	{
		TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
		TSPL_ClearBuffer(printer);
		TSPL_Bar(printer, 60, 60, 400, 30);
		int result = TSPL_Print(printer, 1, 1);
		if (result == 0)
		{
			text = _T(" : Print Bar secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}

void CTSPLDemoDlg::OnClickedButtonDatamatrix()
{
	if (ret == 0)
	{
		TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
		TSPL_ClearBuffer(printer);
		TSPL_Dmatrix(printer, 60, 50, 50, 50, "abcdefg123456789!@#$%^&*()", 8, 4, 4);
		int result = TSPL_Print(printer, 1, 1);
		if (result == 0)
		{
			text = _T(" : Print Datamatrix secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}

void CTSPLDemoDlg::OnClickedButtonBox()
{
	if (ret == 0)
	{
		TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
		TSPL_ClearBuffer(printer);
		TSPL_Box(printer, 60, 60, 400, 200, 5, 1);
		int result = TSPL_Print(printer, 1, 1);
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

void CTSPLDemoDlg::OnClickedButtonBitmap()
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
			TSPL_Setup(printer, 4, 8, 76, 50, 1, 2, 4);
			TSPL_ClearBuffer(printer);
			TSPL_Image(printer, 10, 20, 0, CStringA(strBmpFilePath));
			int result = TSPL_Print(printer, 1, 1);
			if (result == 0)
			{
				text = _T(" : Print Bitmap secceed!");
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

void CTSPLDemoDlg::OnClickedButtonPdf417()
{
	if (ret == 0)
	{
		TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
		TSPL_ClearBuffer(printer);
		TSPL_PDF417(printer, 60, 60, 100, 200, 0, "E3,W3,L10", "ABCDEFGHIJKABCDEFGHIJK123456!@#$%^&");
		int result = TSPL_Print(printer, 1, 1);
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

void CTSPLDemoDlg::OnClickedButtonPrintstatus()
{
	unsigned int status;
	if (ret == 0)
	{
		int  rValue = TSPL_GetPrinterStatus(printer, &status);
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

void CTSPLDemoDlg::OnClickedButtonTextblock()
{
	if (ret == 0)
	{
		TSPL_Setup(printer, 4, 8, 76, 30, 1, 2, 4);
		TSPL_ClearBuffer(printer);
		TSPL_Block(printer, 30, 50, 600, 200, "3", "Welcome to the world of printing ,this is the test ! ", 0, 1, 1, 0);
		int result = TSPL_Print(printer, 1, 1);
		if (result == 0)
		{
			text = _T(" : Print Textblock secceed!");
			SetMsg(text);
		}
	}
	else
	{
		text = _T(" : Fail to send data, please check connection!");
		SetMsg(text);
	}
}
