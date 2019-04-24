// YDControl.cpp : Defines the entry point for the application.
//

#include "stdafx.h"


// extern "C" BOOL KernelIoControl(DWORD dwIoControlCode, LPVOID lpInBuf, DWORD nInBufSize, LPVOID lpOutBuf, DWORD nOutBufSize, LPDWORD lpBytesReturned);
#define IOCTL_HAL_REBOOT            CTL_CODE(FILE_DEVICE_HAL, 15, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define CTL_CODE( DeviceType, Function, Method, Access ) (                 \
    ((DeviceType) << 16) | ((Access) << 14) | ((Function) << 2) | (Method) \
)
#define FILE_ANY_ACCESS 0
#define METHOD_BUFFERED 0
#define FILE_DEVICE_HAL 0x00000101
#define WIN32_CALL(type, api, args)		IMPLICIT_DECL(type, SH_WIN32, W32_ ## api, args)
#define KernelIoControl WIN32_CALL(BOOL, KernelIoControl, (DWORD dwIoControlCode, \
	LPVOID lpInBuf, DWORD nInBufSize, \
	LPVOID lpOutBuf, DWORD nOutBufSize, LPDWORD lpBytesReturned))

#if defined(MIPS)
#define FIRST_METHOD 	0xFFFFFC02
#define APICALL_SCALE	4
#elif defined(x86)
#define FIRST_METHOD 	0xFFFFFE00
#define APICALL_SCALE	2
#elif defined(ARM)
#define FIRST_METHOD 	0xF0010000
#define APICALL_SCALE	4
#elif defined(SHx)
#define FIRST_METHOD 	0xFFFFFE01
#define APICALL_SCALE	2
#else
#error "Unknown CPU type"
#endif

#define HANDLE_SHIFT 	8
#define METHOD_MASK 0x00FF
#define HANDLE_MASK 0x003F
#define W32_KernelIoControl		99

#define IMPLICIT_CALL(hid, mid) (FIRST_METHOD - ((hid)<<HANDLE_SHIFT | (mid))*APICALL_SCALE)

#define IMPLICIT_DECL(type, hid, mid, args) (*(type (*)args)IMPLICIT_CALL(hid, mid))

int WINAPI WinMain(	HINSTANCE hInstance,
					HINSTANCE hPrevInstance,
					LPTSTR    lpCmdLine,
					int       nCmdShow)
{
    if (wcscmp(lpCmdLine, L"REBOOT") == 0)
    {
        KernelIoControl(IOCTL_HAL_REBOOT, NULL, 0, NULL, 0, NULL);
    }
	return 0;
}

