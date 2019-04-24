// ShowParam.cpp : Display various .NET data types both
// by reference and by value.
//
// File Location: \YaoDurant\CPP\PlatformInvoke\ShowParam
//
// Code from _Programming the .NET Compact Framework with C#_
// (c) Copyright 2002-2003 Paul Yao and David Durant. 
// All rights reserved.

#include "stdafx.h"
#include "showparam.h"

LPWSTR pLibName = L"ShowParam - Win32 DLL";

BOOL APIENTRY 
DllMain( HANDLE hModule, 
         DWORD  ul_reason_for_call, 
         LPVOID lpReserved)
{
    return TRUE;
}

//
// ShowBooleanByVal - Display Boolean value passed by value.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowBooleanByVal(BYTE val)
{
    WCHAR wch[128];
    wsprintf(wch, L"BoolByVal = %d", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowBooleanByRef - Display Boolean value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowBooleanByRef(BYTE * val)
{
    WCHAR wch[128];
    wsprintf(wch, L"BoolByRef = %d", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowByteByVal - Display Byte value passed by value.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowByteByVal(BYTE val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowByteByVal = %d", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowByteByRef - Display Byte value passed by reference.
//
extern "C" __declspec ( dllexport )
void WINAPI ShowByteByRef(BYTE * val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowByteByRef = %d", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowSByteByVal - Display SByte value passed by value.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowSByteByVal(CHAR val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowSByteByVal = %d", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowSByteByRef - Display SByte value passed by reference.
//
extern "C"  __declspec ( dllexport ) 
void WINAPI ShowSByteByRef(CHAR * val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowSByteByRef = %d", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowInt16ByVal - Display Int16 value passed by value.
//
extern "C"  __declspec ( dllexport ) 
void WINAPI ShowInt16ByVal(SHORT val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowInt16ByVal = %d", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowInt16ByRef - Display Int16 value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowInt16ByRef(SHORT * val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowInt16ByRef = %d", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowUInt16ByVal - Display UInt16 value passed by value.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowUInt16ByVal(USHORT val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowUInt16ByVal = %d", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowUInt16ByRef - Display UInt16 value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowUInt16ByRef(USHORT * val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowUInt16ByRef = %d", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}


//
// ShowInt32ByVal - Display Int32 value passed by value.
//
extern "C"  __declspec ( dllexport ) 
void WINAPI ShowInt32ByVal(LONG val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowInt32ByVal = %d", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowInt32ByRef - Display Int32 value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowInt32ByRef(LONG * val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowInt32ByRef = %d", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowUInt32ByVal - Display UInt32 value passed by value.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowUInt32ByVal(ULONG val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowUInt32ByVal = %d", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowUInt32ByRef - Display UInt32 value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowUInt32ByRef(ULONG * val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowUInt32ByRef = %d", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowInt64ByVal - Display Int64 value passed by value.
//
extern "C"  __declspec ( dllexport ) 
void WINAPI ShowInt64ByVal(__int64 val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowInt64ByVal = %d", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowInt64ByRef - Display Int64 value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowInt64ByRef(__int64 * val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowInt64ByRef = %d", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowUInt64ByVal - Display UInt64 value passed by value.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowUInt64ByVal(unsigned __int64 val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowUInt64ByVal = %d", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowUInt64ByRef - Display UInt64 value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowUInt64ByRef(unsigned __int64 * val)
{
    WCHAR wch[128];
    wsprintf(wch, L"ShowUInt64ByRef = %d", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}


//
// ShowSingleByVal - Display Single value passed by value.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowSingleByVal(float val)
{
    WCHAR wch[128];
    swprintf(wch, L"ShowSingleByVal = %f", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowSingleByRef - Display Single value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowSingleByRef(float * val)
{
    WCHAR wch[128];
    swprintf(wch, L"ShowSingleByRef = %f", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowDoubleByVal - Display Double value passed by value.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowDoubleByVal(double val)
{
    WCHAR wch[128];
    swprintf(wch, L"ShowDoubleByVal = %f", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowDoubleByRef - Display Double value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowDoubleByRef(double * val)
{
    WCHAR wch[128];
    swprintf(wch, L"ShowDoubleByRef = %f", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowCharByVal - Display Char value passed by value.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowCharByVal(WCHAR val)
{
    WCHAR wch[128];
    swprintf(wch, L"ShowCharByVal = %c", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowCharByRef - Display Char value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowCharByRef(WCHAR * val)
{
    WCHAR wch[128];
    swprintf(wch, L"ShowCharByRef = %c", *val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowStringByVal - Display String value passed by value.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowStringByVal(WCHAR * val)
{
    WCHAR wch[128];
    swprintf(wch, L"ShowStringByVal = %s", val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

//
// ShowStringByRef - Display String value passed by reference.
//
extern "C" __declspec ( dllexport ) 
void WINAPI ShowStringByRef(WCHAR ** val)
{
    WCHAR wch[128];
    swprintf(wch, L"ShowStringByRef = %s", **val);
    MessageBoxW(NULL, wch, pLibName, 0);
}

