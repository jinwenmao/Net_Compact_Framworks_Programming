//--------------------------------------------------------------
// YaoDurantControls.h : Key definitions for event grabber.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2003 Paul Yao and David Durant. 
// All rights reserved.
//--------------------------------------------------------------

extern "C" int CreateEventGrabber(
   HWND hwndControl, 
   HWND hwndGrabber);
extern "C" int DisposeEventGrabber(
   HWND hwndControl);
extern "C" int SetEventFlags(
   HWND hwndControl, 
   int flags);
extern "C" int GetEventFlags(
   HWND hwndControl);

//--------------------------------------------------------------
// Bit-wise flags for the desired event
//--------------------------------------------------------------
#define EVENT_KEYDOWN    0x0001
#define EVENT_KEYPRESS   0x0002
#define EVENT_KEYUP      0x0004
#define EVENT_MOUSEDOWN  0x0008
#define EVENT_MOUSEMOVE  0x0010
#define EVENT_MOUSEUP    0x0020

//--------------------------------------------------------------
// Structure holding event grabber details.
//--------------------------------------------------------------
typedef struct __EVENTGRABBER
{
   HWND hwndControl;  // Handle to CF control.
   HWND hwndGrabber; // Handle to MessageWindow -- dispatcher.
   int  fEvents;      // Events to handle.
   WNDPROC lpfn;      // Original window procedure.
   struct __EVENTGRABBER * pPrev; // Previous item in list.
   struct __EVENTGRABBER * pNext; // Next item in list.
} EVENTGRABBER, *LPEVENTGRABBER;

//--------------------------------------------------------------
// C++ wrapper class for event grabber list.
//--------------------------------------------------------------
class EventGrabberList
{
private:
   LPEVENTGRABBER m_pegHead;
   LPEVENTGRABBER m_pegTail;
public:
   EventGrabberList();
   BOOL AddEventGrabber(HWND hwndCtrl, HWND hwndGrabber, 
      int flags, WNDPROC lpfn);
   LPEVENTGRABBER WINAPI FindEventGrabber(HWND hwnd);
   LPEVENTGRABBER WINAPI FindFirstEventGrabber();
   BOOL WINAPI RemoveEventGrabber(HWND hwnd);
};
