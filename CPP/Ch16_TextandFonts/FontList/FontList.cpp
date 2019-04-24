// FontList.cpp : Win32 Font enumeration helper functions.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2003 Paul Yao and David Durant. 
// All rights reserved.

#include "stdafx.h"
#include "fontlist.h"

BOOL APIENTRY 
DllMain( HANDLE hModule, 
         DWORD  ul_reason_for_call, 
         LPVOID lpReserved)
{
    return TRUE;
}
extern "C"
{

typedef struct __FACENAME
{
   WCHAR FaceName[LF_FACESIZE];
   struct __FACENAME * pNext;
} FACENAME, *LPFACENAME;

typedef struct __HEADER
{
   int signature;
   int count;
   struct __FACENAME * pFirst;
   struct __FACENAME * pLast;
} HEADER, *LPHEADER;


#define HEADER_SIGNATURE 0xf0f0

//--------------------------------------------------------------
//--------------------------------------------------------------

int CALLBACK FontEnumProc(
    const ENUMLOGFONT FAR *lpelf, 
    const TEXTMETRIC FAR *lpntm, 
    int FontType, 
    LPARAM lParam)
{
   LPHEADER pfl = (LPHEADER)lParam;

   // Allocate block to hold facename info.
   LPFACENAME pfnNext = (LPFACENAME)malloc(sizeof(FACENAME));
   if (pfnNext == NULL)
      return FALSE;

   wcscpy(pfnNext->FaceName, lpelf->elfLogFont.lfFaceName);
   pfnNext->pNext = NULL;

   // First time called -- link to header block.
   if (pfl->pFirst == NULL)
   {
       pfl->pFirst = pfnNext;
   }
   else // Link to previous block.
   {
       LPFACENAME pfn = pfl->pLast;
       pfn->pNext = pfnNext;
   }

   // Current block becomes end of list.
   pfl->pLast = pfnNext;

   pfl->count++; // increment face name count.

   return TRUE;
}

//--------------------------------------------------------------
//--------------------------------------------------------------
HANDLE __cdecl FontList_Create(void)
{
   LPHEADER pfl = (LPHEADER)malloc(sizeof(HEADER));
   if (pfl == NULL)
      return NULL;

   // Init font list.
   pfl->count = 0;
   pfl->pFirst = NULL; 
   pfl->pLast = NULL;
   pfl->signature = HEADER_SIGNATURE; 0xf0f0;

   HDC hdc = GetDC(NULL);
   EnumFontFamilies(hdc, NULL, (FONTENUMPROC)FontEnumProc, 
   (LPARAM)pfl);
   ReleaseDC(NULL, hdc);

   return (HANDLE)pfl;
}

//--------------------------------------------------------------
//--------------------------------------------------------------
int __cdecl  FontList_GetCount(HANDLE hFontList)
{
   LPHEADER pfl = (LPHEADER)hFontList;
   if (pfl->signature != HEADER_SIGNATURE)
      return -1;

   return pfl->count; 
}

//--------------------------------------------------------------
//--------------------------------------------------------------
LPTSTR __cdecl   FontList_GetFace(HANDLE  hFontList, int iFace)
{
   LPHEADER pfl = (LPHEADER)hFontList;
   if (pfl->signature != HEADER_SIGNATURE ||
       pfl->count <= iFace)
      return NULL;

   LPFACENAME pfn = pfl->pFirst;
   if (iFace != 0)
   {
      iFace--;
      for (int i = 0; i <= iFace; i++)
      {
         pfn = pfn->pNext;
      }
   }

   return pfn->FaceName;
}

//--------------------------------------------------------------
//--------------------------------------------------------------
BOOL __cdecl   FontList_Destroy(HANDLE hFontList)
{
   LPHEADER pfl = (LPHEADER)hFontList;
   if (pfl->signature == HEADER_SIGNATURE)
      return NULL;

   LPFACENAME pfnFirst = pfl->pFirst;
   LPFACENAME pfnNext;

   int cItems = pfl->count;
   for (int i = 0; i < cItems; i++)
   {
      pfnNext = pfnFirst->pNext;
      free(pfnFirst);
      pfnFirst = pfnNext;
   }

   free(pfl);

   return TRUE;
}


}
