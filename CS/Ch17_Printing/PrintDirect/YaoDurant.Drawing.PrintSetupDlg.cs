// YaoDurant.Drawing.PrintSetupDlg.cs - Generic Print setup 
// dialog box.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Runtime.InteropServices;
using YaoDurant.Win32;

namespace YaoDurant.Drawing
{
   /// <summary>
   /// Summary description for YaoDurant.
   /// </summary>
   public class PrintSetupDlg
   {
      //--------------------------------------------------------
      // Declarations for native printing dialog boxes.
      //--------------------------------------------------------
      [DllImport("commdlg.dll", CharSet=CharSet.Unicode)]
      public static extern 
      int PageSetupDlgW (ref PAGESETUPDLGSTRUCT lppsd);
      [DllImport("commdlg.dll", CharSet=CharSet.Unicode)]
      public static extern int CommDlgExtendedError ();

      //--------------------------------------------------------
      // Clean up memory allocated by call to PageSetupDlgW
      //--------------------------------------------------------
      public static
      void Close (ref PAGESETUPDLGSTRUCT lppsd)
      {
         if (lppsd.hDevMode != IntPtr.Zero)
            NativeHeap.LocalFree(lppsd.hDevMode);
         if (lppsd.hDevNames != IntPtr.Zero)
            NativeHeap.LocalFree(lppsd.hDevNames);
      }
      
      //--------------------------------------------------------
      // Allocate and initialize PAGESETUPDLGSTRUCT structure
      //--------------------------------------------------------
      public static
      void InitDlgStruct(
         ref PAGESETUPDLGSTRUCT psd, 
         IntPtr hwndParent)
      {
         psd.lStructSize = Marshal.SizeOf(psd);
         psd.Flags = 0;
         psd.hwndOwner = hwndParent;
      }

      //--------------------------------------------------------
      // Display dialog box.
      //--------------------------------------------------------
      public static
      int ShowDialog(ref PAGESETUPDLGSTRUCT psd)
      {
         return PageSetupDlgW( ref psd);
      }

      //--------------------------------------------------------
      // Fetch error string
      //--------------------------------------------------------
      public static
      string GetErrorString()
      {
         // User clicked cancel [x] button -or- we have an error.
         int ierrDlg = CommDlgExtendedError();
         if (ierrDlg == 0)
            return "Ok";

         string strReason = string.Empty;

         if (ierrDlg >= (int)PDERR.PRINTERCODES &&
            ierrDlg <= (int)PDERR.DEFAULTDIFFERENT)
         {
            PDERR pderr = (PDERR)ierrDlg;
            strReason = "PDERR_" + pderr.ToString();
         }
         else
         {
            strReason = "0x" + ierrDlg.ToString("x");
         }
         
         return strReason;
      }

      
      //--------------------------------------------------------
      //--------------------------------------------------------
      public static
      string QueryOutputPort(ref PAGESETUPDLGSTRUCT lppsd)
      {
         // Create managed structure for DEVNAMES
         DEVNAMES dn = new DEVNAMES();
         Marshal.PtrToStructure(lppsd.hDevNames, dn);

         // Get base address of native structure
         int iBase = (int)lppsd.hDevNames;

         // Get pointer to output port.
         IntPtr iptrOutput = new IntPtr(iBase + dn.wOutputOffset);
         string strOutput = Marshal.PtrToStringUni(iptrOutput);

         return strOutput;
      }

   } // class

   //--------------------------------------------------------
   //--------------------------------------------------------
   public struct PAGESETUPDLGSTRUCT
   {
      public int lStructSize;
      public IntPtr hwndOwner;
      public IntPtr hDevMode;  // Return value
      public IntPtr hDevNames; // Return value
      public int Flags;
      public System.Drawing.Point ptPaperSize;
      public System.Drawing.Rectangle rtMinMargin;
      public System.Drawing.Rectangle rtMargin;
      public IntPtr hInstance;
      public int lCustData;
      public IntPtr lpfnPageSetupHook;
      public IntPtr lpfnPagePaintHook;
      public IntPtr reserved; // string lpPageSetupTemplateName;
      public IntPtr hPageSetupTemplate;
   };

   /* size of a device name string */
   // #define CCHDEVICENAME 32

   /* size of a form name string */
   // #define CCHFORMNAME 32

   public struct CHARNAME32
   {
      public char ch00, ch01, ch02, ch03, ch04;
      public char ch05, ch06, ch07, ch08, ch09;
      public char ch10, ch11, ch12, ch13, ch14;
      public char ch15, ch16, ch17, ch18, ch19;
      public char ch20, ch21, ch22, ch23, ch24;
      public char ch25, ch26, ch27, ch28, ch29;
      public char ch30, ch31;
   }

   public class DEVNAMES
   {
      public short wDriverOffset;
      public short wDeviceOffset;
      public short wOutputOffset;
      public short wDefault;
   };

   public enum PSD
   {
      MINMARGINS = 0x00000001,
      MARGINS = 0x00000002,
      INTHOUSANDTHSOFINCHES = 0x00000004,
      INHUNDREDTHSOFMILLIMETERS = 0x00000008,
      DISABLEMARGINS = 0x00000010,
      DISABLEPRINTER = 0x00000020,
      DISABLEORIENTATION = 0x00000100,
      RETURNDEFAULT = 0x00000400,
      DISABLEPAPER = 0x00000200,
      ENABLEPAGESETUPHOOK = 0x00002000,
      ENABLEPAGESETUPTEMPLATE = 0x00008000,
      ENABLEPAGESETUPTEMPLATEHANDLE = 0x00020000
   } // enum

   public enum PDERR
   {
      PRINTERCODES = 0x1000,
      SETUPFAILURE = 0x1001,
      PARSEFAILURE = 0x1002,
      RETDEFFAILURE = 0x1003,
      LOADDRVFAILURE = 0x1004,
      GETDEVMODEFAIL = 0x1005,
      INITFAILURE = 0x1006,
      NODEVICES = 0x1007,
      NODEFAULTPRN = 0x1008,
      DNDMMISMATCH = 0x1009,
      CREATEICFAILURE = 0x100A,
      PRINTERNOTFOUND = 0x100B,
      DEFAULTDIFFERENT = 0x100C,
   } // enum

} // namespace

