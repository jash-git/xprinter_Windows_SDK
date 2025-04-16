

typedef void* (__cdecl* pInitPrinter)(const TCHAR* model);
typedef int(__cdecl* pOpenPort)(void* handle, const TCHAR* settin);
typedef int(__cdecl* pClosePort)(void* handle);
typedef int(__cdecl* pReleasePrinter)(void* handle);
typedef int(__cdecl* pWriteData)(void* handle, unsigned char* buffer, size_t size);
typedef int(__cdecl* pReadData)(void* handle, unsigned char* buffer, unsigned int size);
typedef int(__cdecl* pZPL_StartFormat)(void* handle);
typedef int(__cdecl* pZPL_EndFormat)(void* handle);
typedef int(__cdecl* pZPL_Text)(void* handle, int xPos, int yPos, int fontNum, int orientation, int fontWidth, int fontHeight, const TCHAR* text);
typedef int(__cdecl* pZPL_BarCode128)(void* handle, int xPos, int yPos, int orientation, int moduleWidth, int codeHeight, char line, char lineAboveCode, char checkDigit, char mode, const TCHAR* text);
typedef int(__cdecl* pZPL_QRCode)(void* handle, int xPos, int yPos, int orientation, int model, int dpi, char eccLevel, char input, char charMode, const TCHAR* text);
typedef int(__cdecl* pZPL_GraphicBox)(void* handle, int xPos, int yPos, int width, int height, int thickness, int rounding);
typedef int(__cdecl* pZPL_PrintImage)(void* handle, int xPos, int yPos, const TCHAR* imgName);
typedef int(__cdecl* pZPL_DataMatrixBarcode)(void* handle, int xPos, int yPos, int orientation, int codeHeight, int level, int columns, int rows, int formatId, int aspectRatio, const TCHAR* text);
typedef int(__cdecl* pZPL_Text_Block)(void* handle, int xPos, int yPos, int fontNum, int orientation, int fontWidth, int fontHeight, int textblockWidth, int textblockHeight, const TCHAR* text);
typedef int(__cdecl* pZPL_GetPrinterStatus)(void* handle, int* status);
typedef int(__cdecl* pZPL_PrintConfigurationLabel)(void* handle);
typedef int(__cdecl* pZPL_Pdf417)(void* handle, int xPos, int yPos, int orientation, int moduleWidth, int codeHeight, int securityLevel, int columns, int rows, char truncate, const TCHAR* text);

#pragma once


class CZPLDemoDlg : public CDialog
{
public:
	CZPLDemoDlg(CWnd* pParent = nullptr);

#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_ZPL_DEMO_DIALOG };
#endif

protected:
	virtual void DoDataExchange(CDataExchange* pDX);


protected:
	HICON m_hIcon;

	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	CEdit m_msg;
	afx_msg void OnClickedButtonOpen();
	afx_msg void OnClickedButtonClose();
	CButton m_radioUsb;
	CButton m_radioCom;
	CButton m_radioNet;
	afx_msg void OnClickedRadioUsb();
	afx_msg void OnClickedRadioCom();
	afx_msg void OnClickedRadioNet();
	CComboBox m_comboBaudrate;
	CComboBox m_comboComPortName;

	CString msg;

	HINSTANCE hDllInst;

	void* printer = NULL;
	pInitPrinter InitPrinter = NULL;
	pOpenPort OpenPort = NULL;
	pClosePort ClosePort = NULL;
	pReleasePrinter ReleasePrinter = NULL;
	pWriteData WriteData = NULL;
	pReadData ReadData = NULL;
	pZPL_StartFormat ZPL_StartFormat = NULL;
	pZPL_EndFormat ZPL_EndFormat = NULL;
	pZPL_Text ZPL_Text = NULL;
	pZPL_BarCode128 ZPL_BarCode128 = NULL;
	pZPL_QRCode ZPL_QRCode = NULL;
	pZPL_GraphicBox ZPL_GraphicBox = NULL;
	pZPL_PrintImage ZPL_PrintImage = NULL;
	pZPL_DataMatrixBarcode ZPL_DataMatrixBarcode = NULL;
	pZPL_Text_Block ZPL_Text_Block = NULL;
	pZPL_GetPrinterStatus ZPL_GetPrinterStatus = NULL;
	pZPL_PrintConfigurationLabel ZPL_PrintConfigurationLabel = NULL;
	pZPL_Pdf417 ZPL_Pdf417 = NULL;

	int portflag = 0;

	CTime currentTime;
	void GetComList(CUIntArray& ports, CUIntArray& portse, CUIntArray& portsu);
	void AddCom();
	void SetMsg(CString r);
	void EnableBtn(bool e);
	CEdit m_editHost;
	afx_msg void OnClose();
	CButton m_priText;
	afx_msg void OnClickedButtonText();
	afx_msg void OnClickedButtonBarcode();
	afx_msg void OnClickedButtonDatamatrix();
	afx_msg void OnClickedButtonQrcode();
	afx_msg void OnClickedButtonBox();
	afx_msg void OnClickedButtonBitmap();
	afx_msg void OnClickedButtonPdf417();
	afx_msg void OnClickedButtonPrintconfig();
	afx_msg void OnClickedButtonPrintstatus();
	afx_msg void OnClickedButtonTextblock();
};

