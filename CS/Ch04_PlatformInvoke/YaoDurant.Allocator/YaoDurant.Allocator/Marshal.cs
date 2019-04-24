// Marshal.cs - Allocate and free various types of 
// unmanaged memory.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Data;
using System.Runtime.InteropServices;

namespace YaoDurant.Allocator
{
   /// <summary>
   /// Summary description for Class1.
   /// </summary>
   public class Marshal
   {
      public Marshal()
      {
         //
         // TODO: Add constructor logic here
         //
      }

      //------------------------------------------------------------
      // Allocate / free COM memory
      //------------------------------------------------------------
      [DllImport("ole32.dll")]
      public static extern IntPtr CoTaskMemAlloc(int cb);

      [DllImport("ole32.dll")]
      public static extern void CoTaskMemFree(IntPtr pv);


      public static IntPtr AllocCoTaskMem(int cb)
      {
         return CoTaskMemAlloc(cb);
      }
      public static void FreeCoTaskMem(IntPtr ptr)
      {
         CoTaskMemFree(ptr);
      }

      //------------------------------------------------------------
      // Allocate / free regular heap memory
      //------------------------------------------------------------
      [DllImport("COREDLL.DLL")]
      public static extern IntPtr LocalAlloc (int fuFlags, int cbBytes);
      public const int LMEM_FIXED = 0x0000;
      public const int LMEM_ZEROINIT = 0x0040;
      public static IntPtr AllocHGlobal(int cb)
      {
         return LocalAlloc(LMEM_FIXED | LMEM_ZEROINIT, cb);
      }

      public static IntPtr AllocHGlobal(IntPtr cb)
      {
         return AllocHGlobal(cb.ToInt32());
      }

      [DllImport("COREDLL.DLL")]
      public static extern IntPtr LocalFree (IntPtr hMem);
      public static void FreeHGlobal(IntPtr hglobal)
      {
         LocalFree(hglobal);
      }

   } // class
} // namespace
