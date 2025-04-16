

#pragma once

#ifndef __AFXWIN_H__
#error "Include 'pch. h' before including this file to generate PCH"
#endif

#include "resource.h"		



class CZPLDemoApp : public CWinApp
{
public:
	CZPLDemoApp();

public:
	virtual BOOL InitInstance();


	DECLARE_MESSAGE_MAP()
};

extern CZPLDemoApp theApp;
