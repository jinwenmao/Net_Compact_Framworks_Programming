// YaoDurant.Win32.Misc.cs - Generic wrappers for various
// Win32 API functions.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace YaoDurant.Win32
{
   public class NativeHeap
   {
      // Memory allocation functions & definitions.
      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern IntPtr LocalAlloc (int uFlags, int uBytes);
      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern IntPtr LocalFree (IntPtr hMem);
      public const int LPTR = 0x0040;
   }

   public class WinFocus
   {
      [DllImport("coredll.dll")]
      public static extern IntPtr GetFocus ();

      [DllImport("coredll.dll")]
      public static extern IntPtr SetFocus (IntPtr hWnd);
   }

   public class WinIO
   {
      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern 
      IntPtr CreateFile (
         string lpFileName, 
         ACCESS dwDesiredAccess, 
         FILE_SHARE dwShareMode, 
         int Res, 
         FILE_ACTION dwCreationDispostion, 
         FILE_ATTRIBUTE dwFlagsAndAttributes, 
         int Res2);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int CloseHandle (IntPtr hObject);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int WriteFile (IntPtr hFile, Byte [] lpBuffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, IntPtr Res);

      public static IntPtr INVALID_FILE_HANDLE = new IntPtr(-1);
      public enum ACCESS
      {
         READ = unchecked((int)0x80000000),
         WRITE = 0x40000000,
         EXECUTE = 0x20000000,
         ALL = 0x10000000,
         NONE = 0
      }


      public enum FILE_SHARE
      {
         READ = 0x00000001,
         WRITE = 0x00000002,
      }


      public enum FILE_ACTION
      {
         CREATE_NEW = 1,
         CREATE_ALWAYS = 2,
         OPEN_EXISTING = 3,
         OPEN_ALWAYS = 4,
         TRUNCATE_EXISTING = 5,
         OPEN_FOR_LOADER = 6
      }

      public enum FILE_ATTRIBUTE
      {
         READONLY = 0x00000001,
         HIDDEN = 0x00000002,
         SYSTEM = 0x00000004,
         DIRECTORY = 0x00000010,
         ARCHIVE = 0x00000020,
         INROM = 0x00000040,
         ENCRYPTED = 0x00000040,
         NORMAL = 0x00000080,
         TEMPORARY = 0x00000100,
         SPARSE_FILE = 0x00000200,
         REPARSE_POINT = 0x00000400,
         COMPRESSED = 0x00000800,
         OFFLINE = 0x00001000,
         ROMSTATICREF = 0x00001000,
         NOT_CONTENT_INDEXED = 0x00002000,
         ROMMODULE = 0x00002000
      }
      
   }
}
