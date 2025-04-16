

#pragma once
#include "afxcmn.h"
#include "afxwin.h"

typedef void* (__cdecl* pInitPrinter)(const TCHAR* model);
typedef int(__cdecl* pOpenPort)(void* handle, const TCHAR* settin);
typedef int(__cdecl* pReleasePrinter)(void* handle);
typedef int(__cdecl* pWriteData)(void* handle, unsigned char* buffer, size_t size);
typedef int(__cdecl* pReadData)(void* handle, unsigned char* buffer, unsigned int size);
typedef int(__cdecl* pPrinterInitialize)(void* handle);

typedef int(__cdecl* pPrintTextS)(void* hPrinter, const char* data);
typedef int(__cdecl* pPrintAndFeedLine)(void* hPrinter);
typedef int(__cdecl* pPrintBarCode)(void* hPrinter, int bcType, const char* data, int width, int height, int alignment, int hriPosition);
typedef int(__cdecl* pCutPaperWithDistance)(void* hPrinter, int distance);
typedef int(__cdecl* pPrintSymbol)(void* hPrinter, int type, const char* data, int errLevel, int width, int height, int alignment);
typedef int(__cdecl* pSetRelativeHorizontal)(void* hPrinter, int position);
typedef int(__cdecl* pGetPrinterState)(void* hPrinter, unsigned int* printerStatus);
typedef int(__cdecl* pOpenCashDrawer)(void* hPrinter, int pinMode, int onTime, int ofTime);
typedef int(__cdecl* pPrintImage)(void* hPrinter, const char* imagePath, int scaleMode);
typedef int(__cdecl* pSetAlign)(void* hPrinter, int align);
typedef int(__cdecl* pSetTextBold)(void* hPrinter, int bold);
typedef int(__cdecl* pSetTextFont)(void* hPrinter, int font);

class CPOSWindowsSDKDlg : public CDialogEx
{

public:
	CPOSWindowsSDKDlg(CWnd* pParent = NULL);


#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_POSWINDOWSSDK_DIALOG };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);



protected:
	HICON m_hIcon;


	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()

		CButton m_radioUsb;
	CButton m_radioCom;
	CButton m_radioNet;
	CEdit m_editHost;
	CComboBox m_comboComPortName;
	CComboBox m_comboBaudrate;
	CEdit m_editPrinterStatus;
	CEdit m_editCashDrawerStatus;
	CStatic m_staticOpenStatus;

	void* printer = NULL;
	pInitPrinter InitPrinter = NULL;
	pOpenPort OpenPort = NULL;
	pReleasePrinter ReleasePrinter = NULL;
	pWriteData WriteData = NULL;
	pReadData ReadData = NULL;
	pPrinterInitialize PrinterInitialize = NULL;
	pPrintTextS PrintTextS = NULL;
	pPrintAndFeedLine PrintAndFeedLine = NULL;
	pPrintBarCode PrintBarCode = NULL;
	pCutPaperWithDistance CutPaperWithDistance = NULL;
	pPrintSymbol PrintSymbol = NULL;
	pSetRelativeHorizontal SetRelativeHorizontal = NULL;
	pGetPrinterState GetPrinterState = NULL;
	pOpenCashDrawer OpenCashDrawer = NULL;
	pPrintImage PrintImage = NULL;
	pSetAlign SetAlign = NULL;
	pSetTextBold SetTextBold = NULL;
	pSetTextFont SetTextFont = NULL;

	HINSTANCE hDllInst;

public:
	afx_msg void OnBnClickedButtonOpen();
	afx_msg void OnBnClickedButtonClose();
	afx_msg void OnBnClickedButton1();
	afx_msg void OnBnClickedButton2();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedButton4();
	afx_msg void OnBnClickedButton5();
	afx_msg void OnBnClickedButton6();
	afx_msg void OnBnClickedButton7();
	afx_msg void EnableBtn(bool e);
};
