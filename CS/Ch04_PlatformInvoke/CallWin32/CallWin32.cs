// CallWin32.cs - Declarations and functions to call
// Win32 functions in the Win32 library ShowParam.dll.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CallWin32
{
   public class CallWin32
   {
      public const string DllName = "ShowParam.dll";

      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowBooleanByVal (Boolean b);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowBooleanByRef (ref Boolean b);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowByteByVal (Byte val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowByteByRef (ref Byte val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowSByteByVal (SByte val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowSByteByRef (ref SByte val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowInt16ByVal (Int16 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowInt16ByRef (ref Int16 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowUInt16ByVal (UInt16 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowUInt16ByRef (ref UInt16 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowInt32ByVal (Int32 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowInt32ByRef (ref Int32 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowUInt32ByVal (UInt32 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowUInt32ByRef (ref UInt32 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowInt64ByVal (Int64 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowInt64ByRef (ref Int64 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowUInt64ByVal (UInt64 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowUInt64ByRef (ref UInt64 val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowSingleByVal (float val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowSingleByRef (ref float val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowDoubleByVal (Double val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowDoubleByRef (ref Double val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowCharByVal (Char val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowCharByRef (ref Char val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowStringByVal (String val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern void ShowStringByRef (ref String val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern 
      void ShowStringByVal (StringBuilder val);
      [DllImport(DllName, CharSet=CharSet.Unicode)]
      public static extern 
      void ShowStringByRef (ref StringBuilder val);

      public static void
      CallWin32Lib(String strVal, String strType, Boolean bByRef)
      {
         //
         // User selection -- Boolean
         //
         if (strType == "Boolean")
         {
            Boolean b;
            if (strVal == "true") b = true;
            else if (strVal == "false") b = false;
            else
            {
               MessageBox.Show("Boolean needs true or false", 
                  FormMain.strApp);
               return;
            }
            if (bByRef)
            {
               ShowBooleanByRef(ref b);
            }
            else
            {
               ShowBooleanByVal(b);
            }
         }
         //
         // User selection -- Byte
         //
         else if (strType == "Byte")
         {
            Byte bytVal = Byte.Parse(strVal);
            if (bByRef)
            {
               ShowByteByRef(ref bytVal);
            }
            else
            {
               ShowByteByVal(bytVal);
            }
         }
         //
         // User selection -- SByte
         //
         else if (strType == "SByte")
         {
            SByte sbytVal = SByte.Parse(strVal);
            if (bByRef)
            {
               ShowSByteByRef(ref sbytVal);
            }
            else
            {
               ShowSByteByVal(sbytVal);
            }
         }
         //
         // User selection -- Int16
         //
         else if (strType == "Int16")
         {
            Int16 shVal = Int16.Parse(strVal);
            if (bByRef)
            {
               ShowInt16ByRef(ref shVal);
            }
            else
            {
               ShowInt16ByVal(shVal);
            }
         }
         //
         // User selection -- UInt16
         //
         else if (strType == "UInt16")
         {
            UInt16 ushVal = UInt16.Parse(strVal);
            if (bByRef)
            {
               ShowUInt16ByRef(ref ushVal);
            }
            else
            {
               ShowUInt16ByVal(ushVal);
            }
         }
         //
         // User selection -- Int32
         //
         else if (strType == "Int32")
         {
            Int32 iVal = Int32.Parse(strVal);
            if (bByRef)
            {
               ShowInt32ByRef(ref iVal);
            }
            else
            {
               ShowInt32ByVal(iVal);
            }
         }
         //
         // User selection -- UInt32
         //
         else if (strType == "UInt32")
         {
            UInt32 uiVal = UInt32.Parse(strVal);
            if (bByRef)
            {
               ShowUInt32ByRef(ref uiVal);
            }
            else
            {
               ShowUInt32ByVal(uiVal);
            }
         }
         //
         // User selection -- IntPtr
         //
         else if (strType == "IntPtr")
         {
            Int32 iVal = Int32.Parse(strVal);
            if (bByRef)
            {
               ShowInt32ByRef(ref iVal);
            }
            else
            {
               ShowInt32ByVal(iVal);
            }
         }
         //
         // User selection -- Int64
         //
         else if (strType == "Int64")
         {
            Int64 lVal = Int64.Parse(strVal);
            if (bByRef)
            {
               ShowInt64ByRef(ref lVal);
            }
            else
            {
               ShowInt64ByVal(lVal);
            }
         }
         //
         // User selection -- UInt64
         //
         else if (strType == "UInt64")
         {
            UInt64 ulVal = UInt64.Parse(strVal);
            if (bByRef)
            {
               ShowUInt64ByRef(ref ulVal);
            }
            else
            {
               ShowUInt64ByVal(ulVal);
            }
         }
         //
         // User selection -- Single
         //
         else if (strType == "Single")
         {
            Single sinVal = Single.Parse(strVal);
            if (bByRef)
            {
               ShowSingleByRef(ref sinVal);
            }
            else
            {
               ShowSingleByVal(sinVal);
            }
         }
         //
         // User selection -- Double
         //
         else if (strType == "Double")
         {
            Double dblVal = Single.Parse(strVal);
            if (bByRef)
            {
               ShowDoubleByRef(ref dblVal);
            }
            else
            {
               ShowDoubleByVal(dblVal);
            }
         }
         //
         // User selection -- Char
         //
         else if (strType == "Char")
         {
            Char chVal = strVal[0];
            if (bByRef)
            {
               ShowCharByRef(ref chVal);
            }
            else
            {
               ShowCharByVal(chVal);
            }
         }
         //
         // User selection -- String
         //
         else if (strType == "String")
         {
            String strValue = strVal;
            if (bByRef)
            {
               ShowStringByRef(ref strValue);
            }
            else
            {
               ShowStringByVal(strValue);
            }
         }
         //
         // User selection -- StringBuilder
         //
         else if (strType == "StringBuilder")
         {
            StringBuilder sbVal = new StringBuilder(strVal);
            if (bByRef)
            {
               ShowStringByRef(ref sbVal);
            }
            else
            {
               ShowStringByVal(sbVal);
            }
         }
      }
   }
}
