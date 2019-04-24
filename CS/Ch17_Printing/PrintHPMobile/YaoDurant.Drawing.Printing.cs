// YaoDurant.Drawing.Printing.cs - Printing support class.
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
   public class Printing
   {
      // Generic version of CreateDC
      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern IntPtr CreateDC (string lpszDriver, string lpszDevice, string lpszOutput, ref DEVMODE lpInitData);

      // Slightly more efficient version of CreateDC
      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern IntPtr CreateDC (IntPtr lpszDriver, IntPtr lpszDevice, IntPtr lpszOutput, IntPtr lpInitData);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int DeleteDC (IntPtr hdc);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int StartDoc (IntPtr hdc, ref DOCINFO lpdi);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int EndDoc (IntPtr hdc);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int StartPage (IntPtr hDC);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int EndPage (IntPtr hdc);

      //--------------------------------------------------------
      // Create a DC using return values from PageSetupDlgW
      //--------------------------------------------------------
      public static
         IntPtr CreatePrinterDC(ref PAGESETUPDLGSTRUCT lppsd)
      {
         // Create managed structure for DEVNAMES
         DEVNAMES dn = new DEVNAMES();
         Marshal.PtrToStructure(lppsd.hDevNames, dn);

         // Get base address of native structure
         int iBase = (int)lppsd.hDevNames;

         // Get pointer to driver name.
         IntPtr iptrDriver = (IntPtr)(iBase + dn.wDriverOffset);
         string strDriver = Marshal.PtrToStringUni(iptrDriver);

         // Get pointer to device name. 
         IntPtr iptrDevice = (IntPtr)(iBase + dn.wDeviceOffset);
         string strDevice  = Marshal.PtrToStringUni(iptrDevice);

         // Get pointer to output port.
         IntPtr iptrOutput = (IntPtr)(iBase + dn.wOutputOffset);
         string strOutput = Marshal.PtrToStringUni(iptrOutput);

         IntPtr hdc = CreateDC(iptrDriver, iptrDevice, iptrOutput, 
            lppsd.hDevMode);
         return hdc;
      }


   } // class

   public struct DOCINFO
   {
      public int cbSize;
      public IntPtr lpszDocName;
      public IntPtr lpszOutput;
      public IntPtr lpszDatatype;
      public int fwType;
   };

   public struct DEVMODE
   {
      public CHARNAME32 dmDeviceName;  // WCHAR  dmDeviceName[CCHDEVICENAME];
      public short dmSpecVersion;
      public short dmDriverVersion;
      public short dmSize;
      public short dmDriverExtra;
      public int dmFields;
      public short dmOrientation;
      public short dmPaperSize;
      public short dmPaperLength;
      public short dmPaperWidth;
      public short dmScale;
      public short dmCopies;
      public short dmDefaultSource;
      public short dmPrintQuality;
      public short dmColor;
      public short dmDuplex;
      public short dmYResolution;
      public short dmTTOption;
      public short dmCollate;
      public CHARNAME32 dmFormName; // WCHAR  dmFormName[CCHFORMNAME];
      public short dmLogPixels;
      public int dmBitsPerPel;
      public int dmPelsWidth;
      public int dmPelsHeight;
      public int dmDisplayFlags;
      public int dmDisplayFrequency;
   };

} // namespace
