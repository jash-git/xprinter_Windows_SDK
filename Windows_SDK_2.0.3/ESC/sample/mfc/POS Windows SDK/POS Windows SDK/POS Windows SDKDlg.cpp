


#include "stdafx.h"
#include "POS Windows SDK.h"
#include "POS Windows SDKDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_ABOUTBOX };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);

protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(IDD_ABOUTBOX)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()

CPOSWindowsSDKDlg::CPOSWindowsSDKDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(IDD_POSWINDOWSSDK_DIALOG, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDI_ICON1);
}

void CPOSWindowsSDKDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_RADIO1, m_radioUsb);
	DDX_Control(pDX, IDC_RADIO2, m_radioCom);
	DDX_Control(pDX, IDC_RADIO3, m_radioNet);
	DDX_Control(pDX, IDC_EDIT3, m_editHost);
	DDX_Control(pDX, IDC_COMBO_COM_PORT_NAME, m_comboComPortName);
	DDX_Control(pDX, IDC_COMBO_BAUDRATE, m_comboBaudrate);
	DDX_Control(pDX, IDC_EDIT1, m_editPrinterStatus);
	DDX_Control(pDX, IDC_EDIT2, m_editCashDrawerStatus);
}

BEGIN_MESSAGE_MAP(CPOSWindowsSDKDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON_OPEN, &CPOSWindowsSDKDlg::OnBnClickedButtonOpen)
	ON_BN_CLICKED(IDC_BUTTON_CLOSE, &CPOSWindowsSDKDlg::OnBnClickedButtonClose)
	ON_BN_CLICKED(IDC_BUTTON1, &CPOSWindowsSDKDlg::OnBnClickedButton1)
	ON_BN_CLICKED(IDC_BUTTON2, &CPOSWindowsSDKDlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON3, &CPOSWindowsSDKDlg::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON4, &CPOSWindowsSDKDlg::OnBnClickedButton4)
	ON_BN_CLICKED(IDC_BUTTON5, &CPOSWindowsSDKDlg::OnBnClickedButton5)
	ON_BN_CLICKED(IDC_BUTTON6, &CPOSWindowsSDKDlg::OnBnClickedButton6)
	ON_BN_CLICKED(IDC_BUTTON7, &CPOSWindowsSDKDlg::OnBnClickedButton7)
END_MESSAGE_MAP()



BOOL CPOSWindowsSDKDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();


	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	SetIcon(m_hIcon, TRUE);
	SetIcon(m_hIcon, FALSE);

	m_radioUsb.SetCheck(BST_CHECKED);

	m_comboBaudrate.InsertString(-1, _T("9600"));
	m_comboBaudrate.InsertString(-1, _T("19200"));
	m_comboBaudrate.InsertString(-1, _T("38400"));
	m_comboBaudrate.InsertString(-1, _T("57600"));
	m_comboBaudrate.InsertString(-1, _T("115200"));


	for (int i = 0; i < 16; ++i)
	{
		CString str;

		str.Format(_T("COM%d"), i);
		m_comboComPortName.InsertString(-1, str);
	}

	hDllInst = ::LoadLibrary(_T("printer.sdk.dll"));
	if (hDllInst)
	{
		InitPrinter = (pInitPrinter)GetProcAddress(hDllInst, "InitPrinter");
		OpenPort = (pOpenPort)GetProcAddress(hDllInst, "OpenPort");
		ReleasePrinter = (pReleasePrinter)GetProcAddress(hDllInst, "ReleasePrinter");
		WriteData = (pWriteData)GetProcAddress(hDllInst, "WriteData");
		ReadData = (pReadData)GetProcAddress(hDllInst, "ReadData");
		PrinterInitialize = (pPrinterInitialize)GetProcAddress(hDllInst, "PrinterInitialize");
		PrintTextS = (pPrintTextS)GetProcAddress(hDllInst, "PrintTextS");
		PrintAndFeedLine = (pPrintAndFeedLine)GetProcAddress(hDllInst, "PrintAndFeedLine");
		PrintBarCode = (pPrintBarCode)GetProcAddress(hDllInst, "PrintBarCode");
		CutPaperWithDistance = (pCutPaperWithDistance)GetProcAddress(hDllInst, "CutPaperWithDistance");
		PrintSymbol = (pPrintSymbol)GetProcAddress(hDllInst, "PrintSymbol");
		SetRelativeHorizontal = (pSetRelativeHorizontal)GetProcAddress(hDllInst, "SetRelativeHorizontal");
		GetPrinterState = (pGetPrinterState)GetProcAddress(hDllInst, "GetPrinterState");
		OpenCashDrawer = (pOpenCashDrawer)GetProcAddress(hDllInst, "OpenCashDrawer");
		PrintImage = (pPrintImage)GetProcAddress(hDllInst, "PrintImage");
		SetAlign = (pSetAlign)GetProcAddress(hDllInst, "SetAlign");
		SetTextBold = (pSetTextBold)GetProcAddress(hDllInst, "SetTextBold");
		SetTextFont = (pSetTextFont)GetProcAddress(hDllInst, "SetTextFont");

	}
	else
	{
		AfxMessageBox(_T("Failed to load the dynamic library. Procedure printer.sdk.dll"));
	}

	return TRUE;
}

void CPOSWindowsSDKDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}


void CPOSWindowsSDKDlg::OnPaint()
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
		CDialogEx::OnPaint();
	}
}

HCURSOR CPOSWindowsSDKDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CPOSWindowsSDKDlg::OnBnClickedButtonOpen()
{
	if (printer)
	{
		ReleasePrinter(printer);
	}
	printer = InitPrinter(L"");
	if (BST_CHECKED == m_radioUsb.GetCheck())
	{
		int ret = OpenPort(printer, L"USB,");
		if (ret == 0)
		{
			AfxMessageBox(L"USB port opened!", MB_ICONINFORMATION);
			EnableBtn(true);
		}
		else
		{
			AfxMessageBox(L"Fail to open USB port, please check!");
		}
	}
	else if (BST_CHECKED == m_radioCom.GetCheck())
	{
		CString baudrateStr;
		CString portName;

		m_comboBaudrate.GetWindowText(baudrateStr);
		int baudrate = _ttoi(baudrateStr);

		m_comboComPortName.GetWindowText(portName);

		if (baudrate <= 0)
		{
			AfxMessageBox(_T("Please specific a valid com baudrate!"), MB_OK | MB_ICONSTOP);
			return;
		}

		if (portName.GetLength() <= 0)
		{
			AfxMessageBox(_T("Please specific a valid com name!"), MB_OK | MB_ICONSTOP);
			return;
		}
		wchar_t buffer[100] = { 0 };
		const wchar_t* baudrateW = static_cast<const wchar_t*>(baudrateStr);
		const wchar_t* portW = static_cast<const wchar_t*>(portName);
		swprintf_s(buffer, 100, L"%s,%s", portW, baudrateW);
		if (OpenPort(printer, buffer) == 0)
		{
			AfxMessageBox(L"COM port opened!", MB_ICONINFORMATION);
			EnableBtn(true);
		}
		else
		{
			AfxMessageBox(L"Fail to open COM port, please check!");
		};
	}
	else if (BST_CHECKED == m_radioNet.GetCheck())
	{
		CString host;
		m_editHost.GetWindowText(host);
		host.Trim();

		if (host.GetLength() <= 0)
		{
			AfxMessageBox(_T("Please input valid host!"), MB_OK | MB_ICONSTOP);
			return;
		}

		wchar_t buffer[100] = { 0 };
		swprintf_s(buffer, 100, L"NET,%s", host.AllocSysString());
		if (OpenPort(printer, buffer) == 0)
		{
			AfxMessageBox(L"Connect succeed!", MB_ICONINFORMATION);
			EnableBtn(true);
		}
		else
		{
			AfxMessageBox(L"Fail to open NET port, please check!");
		}
	}
	else
	{
		AfxMessageBox(_T("Please choose a valid interface!"), MB_OK | MB_ICONSTOP);
		return;
	}
}


void CPOSWindowsSDKDlg::OnBnClickedButtonClose()
{
	ReleasePrinter(printer);
	EnableBtn(false);
}

void CPOSWindowsSDKDlg::EnableBtn(bool e)
{
	//IDC_BUTTON1
	((CButton*)GetDlgItem(IDC_BUTTON1))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON2))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON3))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON4))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON5))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON6))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON7))->EnableWindow(e);
	((CButton*)GetDlgItem(IDC_BUTTON_OPEN))->EnableWindow(!e);
	((CButton*)GetDlgItem(IDC_BUTTON_CLOSE))->EnableWindow(e);
}

void CPOSWindowsSDKDlg::OnBnClickedButton1()
{
	CString text;
	unsigned int status = 2;
	int ret = GetPrinterState(printer, &status);
	if (ret == 0)
	{
		if (0x12 == status)
		{
			text = "Ready";
		}
		else if ((status & 0b100) > 0)
		{
			text = "Cover opened";
		}
		else if ((status & 0b1000) > 0)
		{
			text = "Feed button has been pressed";
		}
		else if ((status & 0b100000) > 0)
		{
			text = "Printer is out of paper";
		}
		else if ((status & 0b1000000) > 0)
		{
			text = "Error condition";
		}
		else
		{
			text = "Error";
		}
	}
	else
	{
		AfxMessageBox(_T("uniRead failed"));
	}
	CString tag;

	text = tag + _T(": ") + text;
	m_editPrinterStatus.SetWindowText(text);
}


void CPOSWindowsSDKDlg::OnBnClickedButton2()
{
	OpenCashDrawer(printer, 0, 30, 255);
}


void CPOSWindowsSDKDlg::OnBnClickedButton3()
{
	CString statusText;
	unsigned int status = 1;
	int ret = GetPrinterState(printer, &status);
	if (ret > 0)
	{
		if ((status & 0b100) > 0)
		{
			statusText = _T("Cash Drawer Closed");
		}
		else
		{
			statusText = _T("Cash Drawer Opened");
		}
	}
	else
	{
		statusText = _T("uniRead failed");
	}
	CString tag;
	statusText = tag + _T(": ") + statusText;
	m_editCashDrawerStatus.SetWindowText(statusText);
}


void CPOSWindowsSDKDlg::OnBnClickedButton4()
{
	PrinterInitialize(printer);
	SetRelativeHorizontal(printer, 180);
	PrintTextS(printer, "Las vegas,NV5208\r\n");
	PrintAndFeedLine(printer);
	PrintAndFeedLine(printer);
	PrintTextS(printer, "Ticket #30-57320             User:HAPPY\r\n");
	PrintTextS(printer, "Station:52-102          Sales Rep HAPPY\r\n");
	PrintTextS(printer, "10/10/2019 3:55:01PM\r\n");
	PrintTextS(printer, "---------------------------------------\r\n");
	PrintTextS(printer, "Item         QTY         Price    Total\r\n");
	PrintTextS(printer, "Description\r\n");
	PrintTextS(printer, "---------------------------------------\r\n");
	PrintTextS(printer, "100328       1           7.99      7.99\r\n");
	PrintTextS(printer, "MAGARITA MIX 7           7.99      3.96\r\n");
	PrintTextS(printer, "680015       1          43.99     43.99\r\n");
	PrintTextS(printer, "LIME\r\n");
	PrintTextS(printer, "102501       1          43.99     43.99\r\n");
	PrintTextS(printer, "V0DKA\r\n");
	PrintTextS(printer, "021048       1           3.99      3.99\r\n");
	PrintTextS(printer, "ORANGE 3200Z\r\n");
	PrintTextS(printer, "---------------------------------------\r\n");
	PrintTextS(printer, "Subtobal                          60.93\r\n");
	PrintTextS(printer, "8.1% Sales Tax                     3.21\r\n");
	PrintTextS(printer, "2% Concession Recov                1.04\r\n");
	PrintTextS(printer, "---------------------------------------\r\n");
	PrintTextS(printer, "Total                             66.18\r\n");
	PrintBarCode(printer, 73, "1234567890", 3, 150, 0, 2);
	CutPaperWithDistance(printer, 10);
}


void CPOSWindowsSDKDlg::OnBnClickedButton5()
{
	PrintSymbol(printer, 49, "Hello World", 48, 10, 10, 1);
	if (CutPaperWithDistance(printer, 10) != 0)
	{
		AfxMessageBox(L"Fail to send data, please check connection!");
	}
}


void CPOSWindowsSDKDlg::OnBnClickedButton6()
{
	PrintBarCode(printer, 73, "1234567890", 3, 150, 0, 2);
	if (CutPaperWithDistance(printer, 10) != 0)
	{
		AfxMessageBox(L"Fail to send data, please check connection!");
	}
}


void CPOSWindowsSDKDlg::OnBnClickedButton7()
{

	TCHAR tpath[MAX_PATH];
	CFileDialog BmpFileDlg(TRUE);
	BmpFileDlg.m_ofn.lpstrInitialDir = tpath;
	BmpFileDlg.m_ofn.lpstrFilter = _T("Image Files\0*.jpg;*.jpeg;*.png;*.bmp\0All Files\0*.*\0");
	if (IDOK == BmpFileDlg.DoModal())
	{
		CString strBmpFilePath = BmpFileDlg.GetPathName();
		USES_CONVERSION;
		char* s = T2A(strBmpFilePath);
		PrintImage(printer, s, 0);
		if (CutPaperWithDistance(printer, 10) != 0)
		{
			AfxMessageBox(L"Fail to send data, please check connection!");
		}
	}
}
