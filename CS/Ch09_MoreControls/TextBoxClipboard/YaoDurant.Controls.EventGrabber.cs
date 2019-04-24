// YaoDurant.Controls.EventGrabber.cs - Wrapper class for
// control event grabber support provided by 
// YaoDurantControls.dll
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.WindowsCE.Forms;

namespace YaoDurant.Controls
{
   /// <summary>
   /// EventGrabber - managed code wrapper around a generic
   /// event grabber for Compact Framework programs. Note
   /// that this requires an unmanaged code DLL to work
   /// correctly: YaoDurant.Controls.dll.
   /// </summary>
   public class EventGrabber : IDisposable
   {
      private IntPtr m_hwndTarget;
      public EventGrabber(
         IntPtr hwndCtrl,  // Window handle of control
         MessageWindow mw, // A MessageWindow-derived object
         int fEvents)      // Which events to trap
      {
         // We keep a private copy of the window handle.
         m_hwndTarget = hwndCtrl;

         CreateEventGrabber(hwndCtrl, mw.Hwnd);
         SetEventFlags(hwndCtrl, fEvents);
      }

      ~EventGrabber()
      {
         Dispose(false);
      }

      // Required IDisposable method
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      protected virtual void Dispose (bool bExplicit)
      {
         // Explicit call to Dispose from program?
         if (bExplicit)
         {
            // Unhook handler from our program.
            DisposeEventGrabber(m_hwndTarget);
         }
      }

      //--------------------------------------------------------
      // Methods implemented in YaoDurantControls.dll
      //--------------------------------------------------------
      [DllImport("YaoDurantControls.dll")]
      public static extern int CreateEventGrabber (
         IntPtr hwndControl, 
         IntPtr hwndDispatch);
      [DllImport("YaoDurantControls.dll")]
      public static extern int DisposeEventGrabber (
         IntPtr hwndControl);
      [DllImport("YaoDurantControls.dll")]
      public static extern int SetEventFlags (
         IntPtr hwndControl, 
         int flags);
      [DllImport("YaoDurantControls.dll")]
      public static extern int GetEventFlags (
         IntPtr hwndControl);
   } // class
} // namespace
