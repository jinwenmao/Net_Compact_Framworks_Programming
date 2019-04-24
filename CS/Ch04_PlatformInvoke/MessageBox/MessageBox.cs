// MessageBox.cs - Two ways to call Win32 MessageBox
// function using P/Invoke.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace PlatformInvoke
{
   class PI_MessageBox
   {
      public const string strApp = "MessageBox";

      [DllImport("coredll.dll")]
      public static extern int
      MessageBox (IntPtr hWnd, string lpText, string lpCaption,
         int uType);

      public const int MB_OK = 0x00000000;
      public const int MB_OKCANCEL = 0x00000001;
      public const int MB_ABORTRETRYIGNORE = 0x00000002;
      public const int MB_YESNOCANCEL = 0x00000003;
      public const int MB_YESNO = 0x00000004;
      public const int MB_RETRYCANCEL = 0x00000005;
      public const int MB_ICONHAND = 0x00000010;
      public const int MB_ICONQUESTION = 0x00000020;
      public const int MB_ICONEXCLAMATION = 0x00000030;
      public const int MB_ICONASTERISK = 0x00000040;
      public const int MB_ICONWARNING = MB_ICONEXCLAMATION;
      public const int MB_ICONERROR = MB_ICONHAND;
      public const int MB_ICONINFORMATION = MB_ICONASTERISK;
      public const int MB_ICONSTOP = MB_ICONHAND;
      public const int MB_DEFBUTTON1 = 0x00000000;
      public const int MB_DEFBUTTON2 = 0x00000100;
      public const int MB_DEFBUTTON3 = 0x00000200;
      public const int MB_DEFBUTTON4 = 0x00000300;
      public const int MB_APPLMODAL = 0x00000000;
      public const int MB_SETFOREGROUND = 0x00010000;
      public const int MB_TOPMOST = 0x00040000;

      [DllImport("coredll.dll")]
      public static extern int
      MessageBox (IntPtr hWnd, string lpText, string lpCaption,
         MB uType);

      public enum MB
      {
         MB_OK = 0x00000000,
         MB_OKCANCEL = 0x00000001,
         MB_ABORTRETRYIGNORE = 0x00000002,
         MB_YESNOCANCEL = 0x00000003,
         MB_YESNO = 0x00000004,
         MB_RETRYCANCEL = 0x00000005,
         MB_ICONHAND = 0x00000010,
         MB_ICONQUESTION = 0x00000020,
         MB_ICONEXCLAMATION = 0x00000030,
         MB_ICONASTERISK = 0x00000040,
         MB_ICONWARNING = MB_ICONEXCLAMATION,
         MB_ICONERROR = MB_ICONHAND,
         MB_ICONINFORMATION = MB_ICONASTERISK,
         MB_ICONSTOP = MB_ICONHAND,
         MB_DEFBUTTON1 = 0x00000000,
         MB_DEFBUTTON2 = 0x00000100,
         MB_DEFBUTTON3 = 0x00000200,
         MB_DEFBUTTON4 = 0x00000300,
         MB_APPLMODAL = 0x00000000,
         MB_SETFOREGROUND = 0x00010000,
         MB_TOPMOST = 0x00040000
      }
 
      static void Main()
      {
         // Flags defined as set of const values.
         MessageBox(IntPtr.Zero, "One way to define flags",
            strApp, MB_OK | MB_TOPMOST);

         // Flags defined as members of enum
         MessageBox(IntPtr.Zero, "Another way to define flags",
            strApp, MB.MB_OK | MB.MB_TOPMOST);
      }
   }
}
