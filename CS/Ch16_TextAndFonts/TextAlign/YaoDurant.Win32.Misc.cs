// YaoDurant.Win32.Misc.cs - Wrapper for various Win32 functions.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Runtime.InteropServices;

// Win32 helper functions.
namespace YaoDurant.Win32
{
   public class WinFocus
   {
      [DllImport("coredll.dll")]
      public static extern IntPtr GetFocus ();

      [DllImport("coredll.dll")]
      public static extern IntPtr SetFocus (IntPtr hWnd);
   }

   public class NativeHeap
   {
      // Memory allocation functions & definitions.
      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern IntPtr LocalAlloc (int uFlags, int uBytes);
      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern IntPtr LocalFree (IntPtr hMem);
      public const int LPTR = 0x0040;
   }

}  // namespace
