// RapiStartup.cs - Simple thread-free RAPI startup
// with all P/Invoke declarations included.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RapiStartup
{
   public class RapiStartup
   {
      const string m_strAppName = "RapiStartup";

      public RapiStartup()
      {
      }
      
      // -------------------------------------------------------
      // RAPI.DLL Definitions
      // -------------------------------------------------------
      public struct RAPIINIT
      {
         public int cbSize;
         public IntPtr heRapiInit;
         public int hrRapiInit;
      };

      [DllImport("rapi.DLL", CharSet=CharSet.Unicode)]
      public static extern int CeRapiInitEx (ref RAPIINIT p);

      [DllImport("rapi.DLL", CharSet=CharSet.Unicode)]
      public static extern int CeRapiUninit ();

      // Block mode – Set ppIRAPIStream to zero
      [DllImport("rapi.DLL", CharSet=CharSet.Unicode)]
      public static extern int CeRapiInvoke (string pDllPath, 
      string pFunctionName, int cbInput, IntPtr pInput, 
      ref int pcbOutput, ref IntPtr ppOutput, int ppIRAPIStream,
      int dwReserved);

      public const uint S_OK = 0;

      // -------------------------------------------------------
      // Main -- Program entry point
      // -------------------------------------------------------
      public static void Main()
      {
         // Allocate structure for call to CeRapiInitEx
         RAPIINIT ri = new RAPIINIT();
         ri.cbSize = Marshal.SizeOf(ri);

         // Call init function
         int hr = CeRapiInitEx(ref ri);

         // Wrap event handle in corresponding .NET object
         ManualResetEvent mrev = new ManualResetEvent(false);
         mrev.Handle = ri.heRapiInit;

         // Wait five seconds, then fail.
         if (mrev.WaitOne(5000, false) && ri.hrRapiInit == S_OK)
         {
            // Connection established.
            MessageBox.Show("Connection Established", m_strAppName);
         }
         else
         {
            // On failure, disconnect from RAPI.
            CeRapiUninit();

            MessageBox.Show("Timeout - No Device", m_strAppName);
            return;
         }

         // If we get here, we have established a RAPI connection

         // Set up data to send to DLL
         string strHello = "Round-trip data to device and back";
         int cbInput = Marshal.SizeOf(strHello);
         int cbOutput = 0;
         IntPtr ipInput = Marshal.StringToHGlobalUni(strHello);
         IntPtr ipOutput = IntPtr.Zero;

         // Call device-side DLL
         CeRapiInvoke(@"\windows\SimpleBlockModeInvoke.dll",
            "LoopbackInvoke",
            cbInput,
            ipInput,
            ref cbOutput,
            ref ipOutput,
            0, 0);

         // Convert return value to a string.
         string strOutput = Marshal.PtrToStringUni(ipOutput, cbOutput);
         
         // Display resulting string.
         MessageBox.Show(strOutput, "CallDeviceDll");

         // Cleanup.
         CeRapiUninit();
      }

   } // class RapiStartup
} // namespace RapiStartup
