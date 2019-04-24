// YaoDurant.Drawing.Graphics.cs - Wrapper for various Win32 functions
// which deal with a DC.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace YaoDurant.Drawing
{
   public class GdiGraphics
   {
      [DllImport("coredll.dll")]
      public static extern IntPtr GetDC (IntPtr hWnd);

      [DllImport("coredll.dll")]
      public static extern int ReleaseDC (IntPtr hWnd, IntPtr hDC);

      [DllImport("coredll.dll", EntryPoint="ExtTextOutW")]
      public static extern int 
      Real_ExtTextOut (IntPtr hdc, int X, int Y, int fuOptions, 
      IntPtr lprc, string lpString, int cbCount, IntPtr lpDx);

      [DllImport("coredll.dll")]
      public static extern int DeleteObject (IntPtr hObject);

      [DllImport("coredll.dll")]
      public static extern 
      IntPtr SelectObject (IntPtr hdc, IntPtr hgdiobj);

      [DllImport("coredll.dll")]
      public static extern 
      int SetBkMode (IntPtr hdc, BKMODE bkmode);

      public enum BKMODE
      {
         TRANSPARENT = 1,
         OPAQUE = 2
      }

      [DllImport("coredll.dll")]
      public static extern int GetDeviceCaps (IntPtr hdc, int iIndex);

      public const int LOGPIXELSY = 90;

      public static 
      int ExtTextOut(IntPtr hdc, int X, int Y, int fuOptions,
         IntPtr lprc, string lpString, int cbCount, IntPtr lpDx)
      {
         // "Transparent" only touches foreground pixels.
         SetBkMode(hdc, BKMODE.TRANSPARENT);
         
         return Real_ExtTextOut(hdc, X, Y, fuOptions, lprc, lpString, cbCount, lpDx);
      }

   } // class
} // namespace
