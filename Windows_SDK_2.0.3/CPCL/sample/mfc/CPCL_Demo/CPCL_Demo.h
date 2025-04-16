

#pragma once

#ifndef __AFXWIN_H__
#error "Include 'pch.h' before including this file to generate PCH"
#endif

#include "resource.h"		


class CCPCLDemoApp : public CWinApp
{
public:
	CCPCLDemoApp();

public:
	virtual BOOL InitInstance();


	DECLARE_MESSAGE_MAP()
		afx_msg void OnBnClickedPrinterStatus();
};

extern CCPCLDemoApp theApp;
