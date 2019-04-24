// YaoDurant.Drawing.GdiGraphics.cs - Supports native drawing
// with GDI drawing functions.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
using System;
using System.Runtime.InteropServices;

namespace YaoDurant.Drawing
{
   /// <summary>
   /// Summary description for YaoDurant.
   /// </summary>
   public class GdiGraphics
   {
      [DllImport("coredll.dll")]
      public static extern IntPtr GetDC (IntPtr hWnd);

      [DllImport("coredll.dll")]
      public static extern int ReleaseDC (IntPtr hWnd, IntPtr hDC);

      [DllImport("coredll.dll")]
      public static extern int GetDeviceCaps (IntPtr hdc, CAPS iIndex);

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

      public static 
         int ExtTextOut(IntPtr hdc, int X, int Y, int fuOptions,
         IntPtr lprc, string lpString, int cbCount, IntPtr lpDx)
      {
         // "Transparent" only touches foreground pixels.
         SetBkMode(hdc, BKMODE.TRANSPARENT);
         
         return Real_ExtTextOut(hdc, X, Y, fuOptions, lprc, lpString, cbCount, lpDx);
      }

   }  // class

   public enum BKMODE
   {
      TRANSPARENT = 1,
      OPAQUE = 2
   }

   public enum CAPS
   {
      HORZRES =  8,          // Horizontal width in pixels
      VERTRES = 10,          // Vertical height in pixels
      LOGPIXELSY = 90,
      PHYSICALWIDTH   = 110, // Physical Width in device units   
      PHYSICALHEIGHT  = 111, // Physical Height in device units  
      PHYSICALOFFSETX = 112, // Physical Printable Area x margin 
      PHYSICALOFFSETY = 113, // Physical Printable Area y margin 
   }

}  // namespace
