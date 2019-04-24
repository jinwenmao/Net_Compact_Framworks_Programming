//--------------------------------------------------------------
// EventGrabber.cpp : Maintains grabber linked-list
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2003 Paul Yao and David Durant. 
// All rights reserved.
//--------------------------------------------------------------
#include "stdafx.h"
#include "YaoDurantControls.h"

EventGrabberList::EventGrabberList()
{
   m_pegHead = NULL;
   m_pegTail = NULL;
}

//-----------------------------------------------------------
// Add new handler for control.
//-----------------------------------------------------------
BOOL EventGrabberList::AddEventGrabber(
   HWND hwndCtrl, 
   HWND hwndGrabber, 
   int flags, 
   WNDPROC lpfn)
{
   // Allocate memory for event grabber.
   LPEVENTGRABBER peg;
   peg = (LPEVENTGRABBER)malloc(sizeof(EVENTGRABBER));
   if (peg == NULL)
      return FALSE;

   peg->hwndControl = hwndCtrl;
   peg->hwndGrabber = hwndGrabber;
   peg->fEvents = flags;
   peg->lpfn = lpfn;

   // First time called?
   if (m_pegHead == NULL && m_pegTail == NULL)
   {
      m_pegHead = peg;
      m_pegTail = peg;
      peg->pPrev = NULL;
      peg->pNext = NULL;
   }
   else
   {
      // Last becomes second to last.
      m_pegTail->pNext = peg;

      // Last becomes our previous item.
      peg->pPrev = m_pegTail;

      // New item is now last item.
      m_pegTail = peg;
      peg->pNext = NULL;
   }

   return TRUE;
} // AddEventGrabber()

//-----------------------------------------------------------
// Find handler for control.
//-----------------------------------------------------------
LPEVENTGRABBER WINAPI EventGrabberList::FindEventGrabber(HWND hwnd)
{
   LPEVENTGRABBER peg;
   for (peg = m_pegHead; 
        peg != NULL; 
        peg = peg->pNext)
   {
      if (peg->hwndControl == hwnd)
         return peg;
   }

   return peg;
} // FindEventGrabber()

//-----------------------------------------------------------
// Find first grabber in list (cleanup helper).
//-----------------------------------------------------------
LPEVENTGRABBER WINAPI EventGrabberList::FindFirstEventGrabber()
{
   return m_pegHead;
} // FindFirstEventGrabber

//-----------------------------------------------------------
// Remove grabber for control.
//-----------------------------------------------------------
BOOL WINAPI EventGrabberList::RemoveEventGrabber(HWND hwnd)
{
   LPEVENTGRABBER peg = FindEventGrabber(hwnd);
   if (peg == NULL)
      return FALSE;

   // Cleanup singleton entry on list
   if (peg->pPrev == NULL && peg->pNext == NULL)
   {
      m_pegHead = NULL;
      m_pegTail = NULL;
   }
   else
   {
      // Fix-up pointer to previous grabber.
      if (peg->pPrev == NULL)
      {
         // Previous item is now head of list.
         m_pegHead = peg->pNext;
      }
      else
      {
         // Previous item gets our next ptr.
         peg->pPrev->pNext = peg->pNext;
      }
      // Fix-up pointer to next grabber.
      if (peg->pNext == NULL)
      {
         m_pegTail = peg->pPrev;
      }
      else
      {
         // Next item gets our previous ptr.
         peg->pNext->pPrev = peg->pPrev;
      }
   }

   // Free memory for grabber.
   free(peg);

   return TRUE;
} // RemoveEventGrabber


