// EnumFlash.cs - Enumeration of flash memory cards
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace FindMemoryCard
{
   /// <summary>
   /// Summary description for EnumFlashCards.
   /// </summary>
   public class EnumFlash
   {
      public EnumFlash()
      {
         //
         // TODO: Add constructor logic here
         //
      }

      // Flash-card search functions.
      [DllImport("note_prj.dll", EntryPoint="FindFirstFlashCard")]
      public static extern IntPtr YD_FindFirstFlashCard (IntPtr lpFindFlashData);
      [DllImport("note_prj.dll", EntryPoint="FindNextFlashCard")]
      public static extern int YD_FindNextFlashCard (IntPtr hFlashCard, IntPtr lpFindFlashData);
      [DllImport("coredll.dll", EntryPoint="FindClose")]
      public static extern int YD_FindClose (IntPtr hFindFile);

      const int MAX_PATH = 260;

      public struct FILETIME
      {
         public int dwLowDateTime;
         public int dwHighDateTime;
      };
      
      public struct WIN32_FIND_DATA
      {
         public int dwFileAttributes;
         public FILETIME ftCreationTime;
         public FILETIME ftLastAccessTime;
         public FILETIME ftLastWriteTime;
         public int nFileSizeHigh;
         public int nFileSizeLow;
         public int dwOID;
         public String cFileName;
      };

      // Memory allocation functions.
      public const int LMEM_FIXED = 0x0000;
      [DllImport("coredll.dll")]
      public static extern IntPtr LocalAlloc (int uFlags, int uBytes);
      [DllImport("coredll.dll")]
      public static extern IntPtr LocalFree (IntPtr hMem);

      public static int INVALID_HANDLE_VALUE = -1;

      //--------------------------------------------------------
      // Buffer needed for find-flash-card functions
      //--------------------------------------------------------
      static IntPtr pFindData = IntPtr.Zero;

      //--------------------------------------------------------
      //--------------------------------------------------------
      private static void 
         CopyIntPtr_to_WIN32_FIND_DATA(IntPtr pIn, 
         ref WIN32_FIND_DATA pffd)
      {
         // Handy values for incrementing IntPtr pointer.
         int i = 0;
         int cbInt = Marshal.SizeOf(i);
         FILETIME ft = new FILETIME();
         int cbFT = Marshal.SizeOf(ft);

         // int dwFileAttributes
         pffd.dwFileAttributes = Marshal.ReadInt32(pIn);
         pIn = (IntPtr)((int)pIn + cbInt);

         // FILETIME ftCreationTime;
         Marshal.PtrToStructure(pIn, pffd.ftCreationTime);
         pIn = (IntPtr)((int)pIn + cbFT);

         // FILETIME ftLastAccessTime;
         Marshal.PtrToStructure(pIn, pffd.ftLastAccessTime);
         pIn = (IntPtr)((int)pIn + cbFT);

         // FILETIME ftLastWriteTime;
         Marshal.PtrToStructure(pIn, pffd.ftLastWriteTime);
         pIn = (IntPtr)((int)pIn + cbFT);

         // int nFileSizeHigh;
         pffd.nFileSizeHigh = Marshal.ReadInt32(pIn);
         pIn = (IntPtr)((int)pIn + cbInt);

         // int nFileSizeLow;
         pffd.nFileSizeLow = Marshal.ReadInt32(pIn);
         pIn = (IntPtr)((int)pIn + cbInt);

         // int dwOID;
         pffd.dwOID = Marshal.ReadInt32(pIn);
         pIn = (IntPtr)((int)pIn + cbInt);

         // String cFileName;
         pffd.cFileName = Marshal.PtrToStringUni(pIn);
      }

      //--------------------------------------------------------
      //--------------------------------------------------------
      public static IntPtr 
      FindFirstFlashCard (ref WIN32_FIND_DATA pffd)
      {
         IntPtr hFF = new IntPtr(INVALID_HANDLE_VALUE);

         // Allocate a block large enough for WIN32_FIND_DATA
         pFindData = LocalAlloc(LMEM_FIXED,560);
         if (pFindData == IntPtr.Zero)
            goto ErrorExit;

         hFF = YD_FindFirstFlashCard(pFindData);
         if (hFF.ToInt32() != INVALID_HANDLE_VALUE)
         {
            CopyIntPtr_to_WIN32_FIND_DATA(pFindData, ref pffd);
         }

         ErrorExit:           
         return hFF;
      } // FindFirstFlashCard

      //--------------------------------------------------------
      //--------------------------------------------------------
      public static bool  FindNextFlashCard (IntPtr hFlashCard, 
         ref WIN32_FIND_DATA pffd)
      {
         bool bRet = false;

         if (pFindData == IntPtr.Zero)
            goto ErrorExit;

         int bMore = YD_FindNextFlashCard(hFlashCard, pFindData);
         if (bMore != 0)
         {
            CopyIntPtr_to_WIN32_FIND_DATA(pFindData, ref pffd);
            bRet = true;
         }

         ErrorExit:           
         return bRet;
      } // FindNextFlashCard

      //--------------------------------------------------------
      //--------------------------------------------------------
      public static bool 
      FindClose (IntPtr hFindFile)
      {
         bool bRet = (YD_FindClose(hFindFile) != 0);

         // Free the memory we allocated.
         if (pFindData != IntPtr.Zero)
         {
            LocalFree(pFindData);
            pFindData = IntPtr.Zero;
         }
         
         return bRet;
      } // FindClose

   } // class
} // namespace
