// SimpleBlockModeInvoke.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"

BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    return TRUE;
}

//--------------------------------------------------------------
// UpperCaseInvoke -- Win32 device-side function
//--------------------------------------------------------------
extern "C" HRESULT __declspec(dllexport) 
UpperCaseInvoke( DWORD cbInput, BYTE  *pInput,
   DWORD *pcbOutput, BYTE  **ppOutput,
   IRAPIStream *pIRAPIStream )
{
   // Init output values.
   *pcbOutput = 0;
   *ppOutput = (BYTE *)NULL;

   if (cbInput != 0)
   {
      // Check for a valid input parameter.
      if (IsBadReadPtr(pInput, cbInput))
         return E_INVALIDARG;

      // Allocate a buffer
      BYTE * pData = (BYTE *)LocalAlloc(LPTR, cbInput);
      if (pData == NULL)
         return E_OUTOFMEMORY;

      // Copy bytes
      memcpy(pData, pInput, cbInput);

      // Make upper-case
      LPWSTR lpwstr = (LPWSTR)pData;
      wcsupr(lpwstr);

      // Send return data to caller.
      *pcbOutput = cbInput;
      *ppOutput = pData;
   }

   return S_OK;

} //UpperCaseInvoke

