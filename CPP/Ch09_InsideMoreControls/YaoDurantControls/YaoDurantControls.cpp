//--------------------------------------------------------------
// YaoDurantControls.cpp : Supports event grabber functions,
// which allow a Compact Framework control to receive Win32
// messages. 
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2003 Paul Yao and David Durant. 
// All rights reserved.
//--------------------------------------------------------------

#include "stdafx.h"
#include "YaoDurantControls.h"
//--------------------------------------------------------------
// Static data.
//--------------------------------------------------------------
EventGrabberList * m_peglist = NULL;  // List of event handlers.

HWND m_hwndLast;          // Cache - last window handle.
LPEVENTGRABBER m_pegLast; // Caceh - last event grabber.

//--------------------------------------------------------------
//--------------------------------------------------------------
BOOL APIENTRY DllMain( 
   HANDLE hModule, 
   DWORD  dwReason, 
   LPVOID lpReserved)
{
   switch (dwReason)
   {
      case DLL_PROCESS_ATTACH:
      case DLL_THREAD_ATTACH:
      case DLL_THREAD_DETACH:
      case DLL_PROCESS_DETACH:
         break;
   }
   return TRUE;
}


//--------------------------------------------------------------

//--------------------------------------------------------------
__inline LPEVENTGRABBER GetEventGrabber(
   HWND hwndControl)
{
   if (hwndControl == m_hwndLast)
      return m_pegLast;
   else
   {
      if (m_peglist == NULL)
         return (LPEVENTGRABBER)NULL;
      m_hwndLast = hwndControl;
      m_pegLast = m_peglist->FindEventGrabber(hwndControl);
      return m_pegLast;
   }
}

//--------------------------------------------------------------
// Helper - the subclass procedure
//--------------------------------------------------------------
LRESULT WINAPI 
ControlSubclassProc(
    HWND hwnd,
    UINT msg,
    WPARAM wParam,
    LPARAM lParam)
{
   LPEVENTGRABBER lpeg = GetEventGrabber(hwnd);
   BOOL bGrabIt = FALSE;
   BOOL bSendIt = TRUE;
   switch(msg)
   {
      case WM_KEYDOWN:
         if (lpeg->fEvents & EVENT_KEYDOWN)
            bGrabIt = TRUE;
         break;
      case WM_CHAR:
         if (lpeg->fEvents & EVENT_KEYPRESS)
            bGrabIt = TRUE;
         break;
      case WM_KEYUP:
         if (lpeg->fEvents & EVENT_KEYUP)
            bGrabIt = TRUE;
         break;
      case WM_LBUTTONDOWN:
         if (lpeg->fEvents & EVENT_MOUSEDOWN)
            bGrabIt = TRUE;
         break;
      case WM_MOUSEMOVE:
         if (lpeg->fEvents & EVENT_MOUSEMOVE)
            bGrabIt = TRUE;
         break;
      case WM_LBUTTONUP:
         if (lpeg->fEvents & EVENT_MOUSEUP)
            bGrabIt = TRUE;
         break;
   } // switch

   // If flag is set, send messages to MessageWindow
   // window in CF program to deliver details about
   // message.
   if (bGrabIt)
   {
      int iResult = 
      SendMessage(lpeg->hwndGrabber, msg, wParam, lParam);

      // Returns whether to send it to original handler.
      if (iResult == 0)
         bSendIt = FALSE;
   }

   // Pass on to original caller.
   if (bSendIt)
      CallWindowProc(lpeg->lpfn, hwnd, msg, wParam, lParam);

   return 0L;
} // ControlSubclassProc

//--------------------------------------------------------------
// Helper - search for window
//--------------------------------------------------------------
BOOL WINAPI IsOnWindowList(
   HWND hwndControl)
{
   LPEVENTGRABBER lpeg = GetEventGrabber(hwndControl);
   return (lpeg != NULL);
}

//--------------------------------------------------------------
// Helper - install sub-class procedure
//--------------------------------------------------------------
BOOL WINAPI 
SubclassControlWindow(
   HWND hwndControl, 
   HWND hwndGrabber)
{
   if (m_peglist == (EventGrabberList *)NULL)
   {
      m_peglist = new EventGrabberList();
   }

   WNDPROC lpfn;
   lpfn = (WNDPROC)GetWindowLong(hwndControl, GWL_WNDPROC);
   SetWindowLong(hwndControl, GWL_WNDPROC, (LONG)ControlSubclassProc);

   m_peglist->AddEventGrabber(hwndControl, hwndGrabber, 0, lpfn);
   return TRUE;
}

//--------------------------------------------------------------
// Helper - uninstall sub-class procedure
//--------------------------------------------------------------
BOOL FreeSubclassControlWindow(
   HWND hwndControl)
{
   LPEVENTGRABBER lpeg = GetEventGrabber(hwndControl);
   if (lpeg == NULL)
      return FALSE;

   // Reset window procedure to original control wndproc.
   WNDPROC lpfn = lpeg->lpfn;
   SetWindowLong(hwndControl, GWL_WNDPROC, (LONG)lpfn);

   // Remove item from our list
   return m_peglist->RemoveEventGrabber(hwndControl);
}

//--------------------------------------------------------------
// Create event grabber
//--------------------------------------------------------------
extern "C" int 
CreateEventGrabber(
   HWND hwndControl, 
   HWND hwndGrabber)
{
   // Check that window handles are valid.
   if (!IsWindow(hwndControl) || !IsWindow(hwndGrabber))
      return 0; 

   // Check whether we already sub-classed this window
   if (IsOnWindowList(hwndControl))
      return 0;

   return (SubclassControlWindow(hwndControl, hwndGrabber));
}

//--------------------------------------------------------------
// Remove sub-class procedure for a specified window.
//--------------------------------------------------------------
extern "C" int DisposeEventGrabber(
   HWND hwndControl)
{
   return (FreeSubclassControlWindow(hwndControl));
}

//--------------------------------------------------------------
// Specify which events to handle.
//--------------------------------------------------------------
extern "C" int SetEventFlags(HWND hwndControl, int flags)
{
   // Check whether window has been sub-classed
   LPEVENTGRABBER lpeg = GetEventGrabber(hwndControl);
   if (lpeg == NULL)
      return FALSE;

   lpeg->fEvents = flags;

   return TRUE;
}

//--------------------------------------------------------------
// Query which events are being handled.
//--------------------------------------------------------------
extern "C" int GetEventFlags(HWND hwndControl)
{
   // Check whether window has been sub-classed
   LPEVENTGRABBER lpeg = GetEventGrabber(hwndControl);
   if (lpeg == NULL)
      return -1;

   return lpeg->fEvents;
}
