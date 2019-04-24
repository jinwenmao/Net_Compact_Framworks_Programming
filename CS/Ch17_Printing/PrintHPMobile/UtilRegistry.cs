// UtilRegistry.cs - Our helpers to access the
// Windows CE registry.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Runtime.InteropServices;    //  SizeOf
using System.Text;                       //  StringBuilder
using YaoDurant.Win32;                   //  Registry access

//  UtilRegistry:  
//     A utility class for reading and writing data to the
//        HKEY.HKEY_LOCAL_MACHINE\SOFTWARE\YaoDurant hive
//        of the registry.

public class UtilRegistry 
{
   private IntPtr hkeyHive = 
      new IntPtr(unchecked((int)WinRegCE.HKEY.HKEY_LOCAL_MACHINE));
   private string  strYDKey = @"SOFTWARE\YaoDurant";
   private IntPtr hkeyCurrent;
   private int intReturn;
   private WinRegCE.REGDISP regdispResult;
   private const int cbMAX = 255;

   
   //  Delete a registry key.
   public bool DeleteKey( string  strKeyName ) 
   {
      intReturn = 
         WinRegCE.RegDeleteKey(hkeyHive, 
                               strYDKey + @"\" + strKeyName);
      if ( intReturn != 0 ) 
      {
         return false;
      }
      return true;
   }

   
   //  Read a System.string  from the registry.
   public bool GetValue(string  strKeyName,  
                        string  strValueName, 
                        ref string  strValue) 
   {
      //  Open HKEY_LOCAL_MACHINE\SOFTWARE\YaoDurant\... 
      //     and have its handle placed in hkeyCurrent. 
      intReturn = 
         WinRegCE.RegCreateKeyEx(hkeyHive, 
                                 strYDKey + @"\" + strKeyName,
                                 0, string.Empty, 0, 0, 
                                 IntPtr.Zero,
                                 ref hkeyCurrent,
                                 ref regdispResult);
      if ( intReturn != 0 ) { return false; }

      //  Create fields to hold the output.
      StringBuilder  sbValue = new StringBuilder(cbMAX);
      int cbValue = cbMAX;

      //  Read the value from the registry into sbValue
      WinRegCE.REGTYPE rtType = 0;
      intReturn = 
         WinRegCE.RegQueryValueEx(hkeyCurrent, strValueName,
                                  0, ref rtType,
                                  sbValue, ref cbValue);
      if ( intReturn != 0 ) { return false; }

      //  Close the key.
      intReturn = WinRegCE.RegCloseKey(hkeyCurrent);
      if ( intReturn != 0 ) { return false; }

      //  Set the string into the output parameter.
      strValue = sbValue.ToString();

      return true;
   }


   //  Read a System.int from the registry.
   public bool GetValue(string  strKeyName,  
      string  strValueName, 
      ref int intValue ) 
   {
      //  Open HKEY_LOCAL_MACHINE\SOFTWARE\YaoDurant\... 
      intReturn = 
         WinRegCE.RegCreateKeyEx(hkeyHive, 
                                 strYDKey + @"\" + strKeyName,
                                 0, string.Empty, 0, 0, 
                                 IntPtr.Zero,
                                 ref hkeyCurrent,
                                 ref regdispResult);
      if ( intReturn != 0 ) { return false; }

      //  Pull the value into intValue.  For platform 
      //     independence, use Marshal.SizeOf(intValue),
      //     not "4", to specify the size in bytes of
      //     a System.int.
      int cbValue = Marshal.SizeOf(intValue);
      WinRegCE.REGTYPE rtType = 0;
      intReturn = 
         WinRegCE.RegQueryValueEx(hkeyCurrent, strValueName,
                                  0, ref rtType,
                                  ref intValue, ref cbValue);
      if ( intReturn != 0 ) { return false; }

      //  Close the key.
      intReturn = WinRegCE.RegCloseKey(hkeyCurrent);
      if ( intReturn != 0 ) { return false; }

      return true;
   }


   //  Read a System.bool from the registry.
   public bool GetValue(string  strKeyName, 
                        string  strValueName, 
                        ref bool boolValue) 
   {
      //  Use the integer version of GetValue to get the value 
      //     from the registry, then convert it to a boolean.
      int intValue =0;
      bool boolReturn = 
         GetValue(strKeyName, strValueName, ref intValue);
      if (boolReturn) 
      {
         boolValue = Convert.ToBoolean(intValue);
      }

      return boolReturn;
   }


   //  Write a System.string  to the registry.
   public bool SetValue(string  strKeyName,  
                        string  strValueName,  
                        string  strValue) 
   {
      //  Open HKEY_LOCAL_MACHINE\SOFTWARE\YaoDurant\... 
      intReturn = 
         WinRegCE.RegCreateKeyEx(hkeyHive, 
                                 strYDKey + @"\" + strKeyName,
                                 0, string.Empty, 0, 0, 
                                 IntPtr.Zero, 
                                 ref hkeyCurrent,
                                 ref regdispResult);
      if ( intReturn != 0 ) { return false; }

      //  Store strValue under the name strValueName.
      intReturn = 
         WinRegCE.RegSetValueEx(hkeyCurrent, strValueName,
                                0, WinRegCE.REGTYPE.REG_SZ,
                                strValue, 
                                strValue.Length * 2 + 1);
      if ( intReturn != 0 ) { return false; }

      //  Close the key.
      intReturn = WinRegCE.RegCloseKey(hkeyCurrent);
      if ( intReturn != 0 ) { return false; }

      return true;
   }

   
   //  Write a System.int to the registry.
   public bool SetValue( string  strKeyName,  string  strValueName,  int intValue ) 
   {
      //  Open HKEY_LOCAL_MACHINE\SOFTWARE\YaoDurant\... 
      intReturn = 
         WinRegCE.RegCreateKeyEx(hkeyHive, 
                                 strYDKey + @"\" + strKeyName,
                                 0, string.Empty, 0, 0, 
                                 IntPtr.Zero, 
                                 ref hkeyCurrent,
                                 ref regdispResult);
      if ( intReturn != 0 ) { return false; }

      //  Store intValue under the name strValueName. for 
      //  platform independence, use Marshal.SizeOf(intValue),
      //     not "4", to specify the size in bytes of a
      //     System.int.
      intReturn = 
         WinRegCE.RegSetValueEx(hkeyCurrent, 
                                strValueName,
                                0, 0,
                                ref intValue, 
                                Marshal.SizeOf(intValue));
      if ( intReturn != 0 ) { return false; }

      //  Close the key.
      intReturn = WinRegCE.RegCloseKey(hkeyCurrent);
      if ( intReturn != 0 ) { return false; }

      return true;
   }


   //  Write a System.bool to the registry.
   public bool SetValue(string  strKeyName,  
                        string  strValueName,  
                        bool boolValue) 
   {

      //  Cast the value as a boolean, then use the integer 
      //     version of SetValue to set the value into the
      //     registry.
      //  There is no Convert.ToInteger method.  For platform      //     independence, we cast to the smallest integer, 
      //     which will always implicitly and successfully cast
      //     to int.
      return SetValue(strKeyName, 
                      strValueName, 
                      Convert.ToInt16(boolValue));
   }

}
