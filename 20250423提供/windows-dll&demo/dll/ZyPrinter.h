//{{NO_DEPENDENCIES}}
// Microsoft Visual C++ ���ɵİ����ļ���
// �� ZyPrinter.h ʹ��
//

#pragma once

#define USE_EXTERN_C 0

#if USE_EXTERN_C
#ifdef __cplusplus  
extern "C" {
#endif  
#endif

//#define ZYPRINTERDLL_API 
//#define ZYFUNcall
#define ZYPRINTERDLL_API __declspec(dllexport)
#define ZYFUNcall __stdcall

/************************************************************************************/
//printer verified api
ZYPRINTERDLL_API int   ZYFUNcall printer_verified_initial(char *password, unsigned char mode);;
ZYPRINTERDLL_API UINT8 ZYFUNcall Get_printer_verified();
ZYPRINTERDLL_API UINT8 ZYFUNcall Set_printer_verified(UINT8 flag);
ZYPRINTERDLL_API int   ZYFUNcall CompareData(char *s1, char *s2, UINT16 bLength);
ZYPRINTERDLL_API UINT8 ZYFUNcall Creat_validation_data_packet(char *ValiBuffer, char  *EncryptBuffer);
ZYPRINTERDLL_API UINT8 ZYFUNcall Creat_set_password_data_packet(char *Buffer);
ZYPRINTERDLL_API UINT8 ZYFUNcall Creat_host_verified_confirmation_data_packet(char *Buffer);

/************************************************************************************/
#define USB_PORT 1
#define COM_PORT 2
#define NET_PORT 3
#define LPT_PORT 4

/*
���ַ����ķ�ʽ���͵�ֵ��Hex����, ��ָ����ͨѶ�˿�
printerPort : xxx_PORT �е�����һ��
fs: �Ѵ򿪵Ķ˿�fs
str: �ַ���
����:
1 :  ���ͳɹ�
0 :  ����ʧ��
-1 : ���������ڴ�ʧ��
-2 : str������ݸ�ʽ����ȷ,ת��ʧ��
-3 printerPort ��������
*/
ZYPRINTERDLL_API int ZYFUNcall SendHexByStringW(int printerPort, int fs,  const wchar_t* str);
ZYPRINTERDLL_API int ZYFUNcall SendHexByStringA(int printerPort, int fs,  const char* str);

/*��ָ���Ķ˿ڷ����ַ���,ʹ��ָ���Ĵ���ҳ
codePage : ��ϸ��ֵ��ο���ײ��Ĵ���ҳ���, ����:GB2312 �� codePage=936
*/
ZYPRINTERDLL_API int ZYFUNcall SendStringW(int printerPort, int fs,  const wchar_t* str, int codePage);
ZYPRINTERDLL_API int ZYFUNcall SendStringA(int printerPort, int fs,  const char* str);

/*
������ָֽ��
mode: 0->ȫ��, ��������
*/
ZYPRINTERDLL_API int ZYFUNcall SendCmd_CutPaper(int printerPort, int fs, int mode);
/*
���ʹ�ӡ������ָ��
line: ���� 0<line<100
*/
ZYPRINTERDLL_API int ZYFUNcall SendCmd_LineFeed(int printerPort, int fs, int line);

/********���ڴ�ӡ������API*************/
ZYPRINTERDLL_API int ZYFUNcall InitNetSev(); //����SOCKET����
ZYPRINTERDLL_API int ZYFUNcall ConnectNetPort(int addr, int port, int Timeout);

/*
����ͬConnectNetPort
��Ӧ������ʽ
192  .168  .1    .1
addr0.addr1.addr2.addr3
*/
ZYPRINTERDLL_API int ZYFUNcall ConnectNetPortEx(int addr0, int addr1, int addr2, int addr3, int port, int Timeout);

/*
��ָ��������,����sendbuf������������
UINT16 fs : ConnectNetPort�ɹ����صľ��
char *SendBuf : Ҫ���͵����ݻ�������ַ
UINT16 WriteSize : Ҫ���͵����ݳ���(byte)
����ʵ�ʷ��͵��ֽ���
*/
ZYPRINTERDLL_API int ZYFUNcall WriteToNetPort(int fs, char *SendBuf, int WriteSize);
/*
��ָ��������,�������ݵ�������
UINT16 fs : ConnectNetPort�ɹ����صľ��
char *SendBuf : �������ݻ�������ַ
UINT16 WriteSize : ���ջ�������С(byte)
����ʵ�ʽ��յ����ֽ���
*/
ZYPRINTERDLL_API int ZYFUNcall ReadFromNetPort(int fs, char *RecvBuf, int RecvBufSize);
ZYPRINTERDLL_API int ZYFUNcall CloseNetPor(int fs);
ZYPRINTERDLL_API int ZYFUNcall CloseNetServ();
ZYPRINTERDLL_API int ZYFUNcall Netportwrite(int addr, int port, int Timeout, int iLen, char* Data);

/********USB�ڴ�ӡ������API**************/
ZYPRINTERDLL_API int ZYFUNcall OpenUsb();
ZYPRINTERDLL_API int ZYFUNcall OpenUsbTO(int timeOut);
ZYPRINTERDLL_API int ZYFUNcall OpenUsbEx(int vid,int pid);
ZYPRINTERDLL_API int ZYFUNcall WriteUsb(int fs,char *SendBuf, int SendBufSize);
ZYPRINTERDLL_API int ZYFUNcall ReadUsb(int fs,char *ReadBuf,int ReadBufSize );
ZYPRINTERDLL_API int ZYFUNcall CloseUsb(int fs);
ZYPRINTERDLL_API int ZYFUNcall usbportwrite(char* VId, char* PId, UINT32 iLen, char* Data);

/********���ڴ�ӡ������API**************/
ZYPRINTERDLL_API int ZYFUNcall OpenLptW(char* Name);
ZYPRINTERDLL_API int ZYFUNcall OpenLptA(LPCSTR lpLptName);
ZYPRINTERDLL_API int ZYFUNcall WriteLpt(int fs, char *SendBuf, int SendBufSize);
ZYPRINTERDLL_API int ZYFUNcall ReadLpt(int fs, char *ReadBuf, int ReadBufSize);
ZYPRINTERDLL_API int ZYFUNcall CloseLpt(int fs);
ZYPRINTERDLL_API int ZYFUNcall Lptportwrite(char* Name, int iLen, char* Data);

/***********************���ڴ�ӡ������API**************/
ZYPRINTERDLL_API int ZYFUNcall OpenComW(char *Com,
										UINT32 BaudRate,
										UINT8 Parity,
										UINT8 ByteSize,
										UINT8 fDtrControl,
										UINT8 StopBits);

ZYPRINTERDLL_API HANDLE ZYFUNcall OpenComA(LPCSTR lpCom,DWORD BaudRate);
ZYPRINTERDLL_API int    ZYFUNcall ReadCom(UINT16 fs, char *ReadBuf, UINT16 SendBufSize );
ZYPRINTERDLL_API int    ZYFUNcall WriteCom(UINT16 fs, char *SendBuf, DWORD WriteSize);
ZYPRINTERDLL_API BOOL   ZYFUNcall CloseCom(UINT16 fs);
ZYPRINTERDLL_API int    ZYFUNcall comportwrite(char *Com,
										UINT32 BaudRate,
										UINT8 Parity,
										UINT8 ByteSize,
										UINT8 fDtrControl,
										UINT8 StopBits,
										UINT32 iLen,
										char* Data);

/********** �ַ���ת����֧�ֵĴ���ҳ *********************/
/*
����ҳ	����	��ʾ����
37	IBM037	IBM EBCDIC������ - ���ô�
437	IBM437	OEM ����
500	IBM500	IBM EBCDIC�����ʣ�
708	ASMO - 708	�������ַ�(ASMO 708)
720	DOS - 720	�������ַ�(DOS)
737	ibm737	ϣ���ַ�(DOS)
775	ibm775	���޵ĺ��ַ�(DOS)
850	ibm850	��ŷ�ַ�(DOS)
852	ibm852	��ŷ�ַ�(DOS)
855	IBM855	OEM �������
857	ibm857	�������ַ�(DOS)
858	IBM00858	OEM ������������ I
860	IBM860	��������(DOS)
861	ibm861	������(DOS)
862	DOS - 862	ϣ�����ַ�(DOS)
863	IBM863	���ô���(DOS)
864	IBM864	�������ַ�(864)
865	IBM865	��ŷ�ַ�(DOS)
866	cp866	������ַ�(DOS)
869	ibm869	�ִ�ϣ���ַ�(DOS)
870	IBM870	IBM EBCDIC�������������� 2��
874	windows - 874	̩��(Windows)
875	cp875	IBM EBCDIC���ִ�ϣ���
932	shift_jis	����(Shift - JIS)
936	gb2312	��������(GB2312) *
949	ks_c_5601 - 1987	������
950	big5	��������(Big5)
1026	IBM1026	IBM EBCDIC�������������� 5��
1047	IBM01047	IBM ������ 1
1140	IBM01140	IBM EBCDIC������ - ���ô� - ŷ�ޣ�
1141	IBM01141	IBM EBCDIC���¹� - ŷ�ޣ�
1142	IBM01142	IBM EBCDIC������ - Ų�� - ŷ�ޣ�
1143	IBM01143	IBM EBCDIC������ - ��� - ŷ�ޣ�
1144	IBM01144	IBM EBCDIC������� - ŷ�ޣ�
1145	IBM01145	IBM EBCDIC�������� - ŷ�ޣ�
1146	IBM01146	IBM EBCDIC��Ӣ�� - ŷ�ޣ�
1147	IBM01147	IBM EBCDIC������ - ŷ�ޣ�
1148	IBM01148	IBM EBCDIC������ - ŷ�ޣ�
1149	IBM01149	IBM EBCDIC�������� - ŷ�ޣ�
1200	utf - 16	Unicode *
1201	unicodeFFFE	Unicode(Big - Endian) *
1250	windows - 1250	��ŷ�ַ�(Windows)
1251	windows - 1251	������ַ�(Windows)
1252	Windows - 1252	��ŷ�ַ�(Windows) *
1253	windows - 1253	ϣ���ַ�(Windows)
1254	windows - 1254	�������ַ�(Windows)
1255	windows - 1255	ϣ�����ַ�(Windows)
1256	windows - 1256	�������ַ�(Windows)
1257	windows - 1257	���޵ĺ��ַ�(Windows)
1258	windows - 1258	Խ���ַ�(Windows)
1361	Johab	������(Johab)
10000	macintosh	��ŷ�ַ�(Mac)
10001	x - mac - japanese	����(Mac)
10002	x - mac - chinesetrad	��������(Mac)
10003	x - mac - korean	������(Mac) *
10004	x - mac - arabic	�������ַ�(Mac)
10005	x - mac - hebrew	ϣ�����ַ�(Mac)
10006	x - mac - greek	ϣ���ַ�(Mac)
10007	x - mac - cyrillic	������ַ�(Mac)
10008	x - mac - chinesesimp	��������(Mac) *
10010	x - mac - romanian	����������(Mac)
10017	x - mac - ukrainian	�ڿ�����(Mac)
10021	x - mac - thai	̩��(Mac)
10029	x - mac - ce	��ŷ�ַ�(Mac)
10079	x - mac - icelandic	������(Mac)
10081	x - mac - turkish	�������ַ�(Mac)
10082	x - mac - croatian	���޵�����(Mac)
12000	utf - 32	Unicode(UTF - 32) *
12001	utf - 32BE	Unicode(UTF - 32 Big - Endian) *
20000	x - Chinese - CNS	��������(CNS)
20001	x - cp20001	TCA ̨��
20002	x - Chinese - Eten	��������(Eten)
20003	x - cp20003	IBM5550 ̨��
20004	x - cp20004	TeleText ̨��
20005	x - cp20005	Wang ̨��
20105	x - IA5	��ŷ�ַ�(IA5)
20106	x - IA5 - German	����(IA5)
20107	x - IA5 - Swedish	�����(IA5)
20108	x - IA5 - Norwegian	Ų����(IA5)
20127	us - ascii	US - ASCII *
20261	x - cp20261	T.61
20269	x - cp20269	ISO - 6937
20273	IBM273	IBM EBCDIC���¹���
20277	IBM277	IBM EBCDIC������ - Ų����
20278	IBM278	IBM EBCDIC������ - ��䣩
20280	IBM280	IBM EBCDIC���������
20284	IBM284	IBM EBCDIC����������
20285	IBM285	IBM EBCDIC��Ӣ����
20290	IBM290	IBM EBCDIC������Ƭ������
20297	IBM297	IBM EBCDIC��������
20420	IBM420	IBM EBCDIC���������
20423	IBM423	IBM EBCDIC��ϣ���
20424	IBM424	IBM EBCDIC��ϣ�����
20833	x - EBCDIC - KoreanExtended	IBM EBCDIC����������չ��
20838	IBM - Thai	IBM EBCDIC��̩�
20866	koi8 - r	������ַ�(KOI8 - R)
20871	IBM871	IBM EBCDIC�������
20880	IBM880	IBM EBCDIC����������
20905	IBM905	IBM EBCDIC���������
20924	IBM00924	IBM ������ 1
20932	EUC - JP	���JIS 0208 - 1990 �� 0212 - 1990��
20936	x - cp20936	��������(GB2312 - 80) *
20949	x - cp20949	������ Wansung *
21025	cp1025	IBM EBCDIC�����������ά�� - ���������
21866	koi8 - u	������ַ�(KOI8 - U)
28591	iso - 8859 - 1	��ŷ�ַ�(ISO) *
28592	iso - 8859 - 2	��ŷ�ַ�(ISO)
28593	iso - 8859 - 3	������ 3 (ISO)
28594	iso - 8859 - 4	���޵ĺ��ַ�(ISO)
28595	iso - 8859 - 5	������ַ�(ISO)
28596	iso - 8859 - 6	�������ַ�(ISO)
28597	iso - 8859 - 7	ϣ���ַ�(ISO)
28598	iso - 8859 - 8	ϣ�����ַ�(ISO - Visual) *
28599	iso - 8859 - 9	�������ַ�(ISO)
28603	iso - 8859 - 13	��ɳ������(ISO)
28605	iso - 8859 - 15	������ 9 (ISO)
29001	x - Europa	ŷ�ް�
38598	iso - 8859 - 8 - i	ϣ�����ַ�(ISO - Logical) *
50220	iso - 2022 - jp	����(JIS) *
50221	csISO2022JP	���JIS - ���� 1 �ֽڼ����� *
50222	iso - 2022 - jp	���JIS - ���� 1 �ֽڼ��� - SO / SI�� *
50225	iso - 2022 - kr	������(ISO) *
50227	x - cp50227	��������(ISO - 2022) *
51932	euc - jp	����(EUC) *
51936	EUC - CN	��������(EUC) *
51949	euc - kr	������(EUC) *
52936	hz - gb - 2312	��������(HZ) *
54936	GB18030	��������(GB18030) *
57002	x - iscii - de	ISCII ���� *
57003	x - iscii - be	ISCII �ϼ����� *
57004	x - iscii - ta	ISCII ̩�׶��� *
57005	x - iscii - te	ISCII ̩¬���� *
57006	x - iscii - as	ISCII ����ķ�� *
57007	x - iscii - or	ISCII �������� *
57008	x - iscii - ka	ISCII ���ɴ��� *
57009	x - iscii - ma	ISCII ��������ķ�ַ� *
57010	x - iscii - gu	ISCII �ż������ַ� *
57011	x - iscii - pa	ISCII �������ַ� *
65000	utf - 7	Unicode(UTF - 7) *
65001	utf - 8	Unicode(UTF - 8)	*
*/

#if USE_EXTERN_C
#ifdef __cplusplus  
}
#endif  
#endif