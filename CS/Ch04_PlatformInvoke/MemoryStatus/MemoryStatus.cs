// MemoryStatus.cs - Displays system memory status
// by calling a Win32 function and passing a pointer to a data
// structure.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MemoryStatus
{
   public class MemoryStatus
   {
      [DllImport("coredll.dll")]
      public static extern 
      void GlobalMemoryStatus (ref MEMORYSTATUS lpBuffer);

      public struct MEMORYSTATUS
      {
         public int dwLength;
         public int dwMemoryLoad;
         public int dwTotalPhys;
         public int dwAvailPhys;
         public int dwTotalPageFile;
         public int dwAvailPageFile;
         public int dwTotalVirtual;
         public int dwAvailVirtual;
      };
      const string CRLF = "\r\n";
   
      public static void Main()
      {
         MEMORYSTATUS ms = new MEMORYSTATUS();
         ms.dwLength = Marshal.SizeOf(ms);
         GlobalMemoryStatus(ref ms);
         
         string strAppName = "Memory Status";
         
         StringBuilder sbMessage = new StringBuilder();
         sbMessage.Append("Memory Load = ");
         sbMessage.Append(ms.dwMemoryLoad.ToString() + "%");
         sbMessage.Append(CRLF);
         sbMessage.Append("Total RAM = ");
         sbMessage.Append(ms.dwTotalPhys.ToString("#,##0"));
         sbMessage.Append(CRLF);
         sbMessage.Append("Avail RAM = ");
         sbMessage.Append(ms.dwAvailPhys.ToString("#,##0"));
         sbMessage.Append(CRLF);
         sbMessage.Append("Total Page = ");
         sbMessage.Append(ms.dwTotalPageFile.ToString("#,##0"));
         sbMessage.Append(CRLF);
         sbMessage.Append("Avail Page = ");
         sbMessage.Append(ms.dwAvailPageFile.ToString("#,##0"));
         sbMessage.Append(CRLF);
         sbMessage.Append("Total Virt = ");
         sbMessage.Append(ms.dwTotalVirtual.ToString("#,##0"));
         sbMessage.Append(CRLF);
         sbMessage.Append("Avail Virt = ");
         sbMessage.Append(ms.dwAvailVirtual.ToString("#,##0"));

         MessageBox.Show(sbMessage.ToString(), strAppName);
      }
   }
}
