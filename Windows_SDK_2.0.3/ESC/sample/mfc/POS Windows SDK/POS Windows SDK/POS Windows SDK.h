

#pragma once

#ifndef __AFXWIN_H__
#error ""
#endif

#include "resource.h"		


// 
//

class CPOSWindowsSDKApp : public CWinApp
{
public:
	CPOSWindowsSDKApp();

public:
	virtual BOOL InitInstance();



	DECLARE_MESSAGE_MAP()
};

extern CPOSWindowsSDKApp theApp;