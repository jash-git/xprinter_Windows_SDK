



typedef void* (__cdecl* pInitPrinter)(const TCHAR* model);
typedef int(__cdecl* pOpenPort)(void* handle, const TCHAR* settin);
typedef int(__cdecl* pClosePort)(void* handle);
typedef int(__cdecl* pReleasePrinter)(void* handle);
typedef int(__cdecl* pWriteData)(void* handle, unsigned char* buffer, size_t size);
typedef int(__cdecl* pReadData)(void* handle, unsigned char* buffer, unsigned int size);
typedef int(__cdecl* pCPCL_AddLabel)(void* handle, int offSet, int height, int qty);
typedef int(__cdecl* pCPCL_SetAlign)(void* handle, int align);
typedef int(__cdecl* pCPCL_AddText)(void* handle, int rotate, const char* fontType, int fontSize, int xPos, int yPos, const TCHAR* data);
typedef int(__cdecl* pCPCL_AddBarCode)(void* handle, int rotate, int type, int width, int ratio, int height, int xPos, int yPos, const TCHAR* data);
typedef int(__cdecl* pCPCL_AddBarCodeText)(void* handle, int enable, int fontType, int fontSize, int offset);
typedef int(__cdecl* pCPCL_AddQRCode)(void* handle, int rotate, int xPos, int yPos, int model, int unitWidth, int eccLevel, const TCHAR* data);
typedef int(__cdecl* pCPCL_AddPDF417)(void* handle, int rotate, int xPos, int yPos, int xDots, int yDots, int columns, int eccLevel, const TCHAR* data);
typedef int(__cdecl* pCPCL_AddBox)(void* handle, int xPos, int yPos, int endXPos, int endYPos, int thickness);
typedef int(__cdecl* pCPCL_AddLine)(void* handle, int xPos, int yPos, int endXPos, int endYPos, int thickness);
typedef int(__cdecl* pCPCL_AddImage)(void* handle, int rotate, int xPos, int yPos, const TCHAR* filePath);
typedef int(__cdecl* pCPCL_SetTextUnderline)(void* handle, int underline);
typedef int(__cdecl* pCPCL_Print)(void* handle);
typedef int(__cdecl* pCPCL_GetPrinterStatus)(void* handle, int* Status);


#pragma once

class CCPCLDemoDlg : public CDialog
{
public:
	CCPCLDemoDlg(CWnd* pParent = nullptr);

#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_CPCL_DEMO_DIALOG };
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


	HINSTANCE hDllInst;

	void* printer = NULL;
	pInitPrinter InitPrinter = NULL;
	pOpenPort OpenPort = NULL;
	pClosePort ClosePort = NULL;
	pReleasePrinter ReleasePrinter = NULL;
	pWriteData WriteData = NULL;
	pReadData ReadData = NULL;
	pCPCL_AddLabel CPCL_AddLabel = NULL;
	pCPCL_SetAlign CPCL_SetAlign = NULL;
	pCPCL_AddText CPCL_AddText = NULL;
	pCPCL_AddBarCode CPCL_AddBarCode = NULL;
	pCPCL_AddBarCodeText CPCL_AddBarCodeText = NULL;
	pCPCL_AddQRCode CPCL_AddQRCode = NULL;
	pCPCL_AddPDF417 CPCL_AddPDF417 = NULL;
	pCPCL_AddBox CPCL_AddBox = NULL;
	pCPCL_AddLine CPCL_AddLine = NULL;
	pCPCL_AddImage CPCL_AddImage = NULL;
	pCPCL_SetTextUnderline CPCL_SetTextUnderline = NULL;
	pCPCL_Print CPCL_Print = NULL;
	pCPCL_GetPrinterStatus CPCL_GetPrinterStatus = NULL;

	void GetComList(CUIntArray& ports, CUIntArray& portse, CUIntArray& portsu);
	void AddCom();
	void SetMsg(CString r);
	void EnableBtn(bool e);

	CTime currentTime;
	CString msg;
	int portflag = 0;

	afx_msg void OnClickedButtonOpen();
	CButton m_radioUsb;
	CButton m_radioCom;
	CButton m_radioNet;
	CEdit m_msg;
	CEdit m_editHost;
	CComboBox m_comboComPortName;
	CComboBox m_comboBaudrate;
	afx_msg void OnClickedRadioUsb();
	afx_msg void OnClickedRadioNet();
	afx_msg void OnClickedRadioCom();
	afx_msg void OnClickedButtonClose();
	afx_msg void OnClickedButtonText();
	afx_msg void OnClickedButtonBarcode();
	afx_msg void OnClickedButtonQrcode();
	afx_msg void OnClickedButtonPdf417();
	afx_msg void OnClickedButtonLine();
	afx_msg void OnClickedButtonBox();
	afx_msg void OnClickedButtonBitmap();
	afx_msg void OnClose();
	afx_msg void OnClickedButtonTextunderline();
	afx_msg void OnBnClickedPrinterStatus();
};
