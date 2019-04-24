// Program: RegShowStartup.exe
//
// RapiEnumRegistryThread.cs - Create a thread to 
// enumerate both registry keys and registry values.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using YaoDurant.Win32;

namespace RegShowStartup
{
   // Reasons our thread invokes user-interface thread.
   public enum INVOKE_ENUMREG
   {
      ENUMREG_NEWKEY,
      ENUMREG_NEWVALUE,
      ENUMREG_ENDED,
      STATUS_MESSAGE
   }

   /// <summary>
   /// RapiConnection - Manages RAPI Remote API connections
   /// </summary>
   public class RapiEnumRegistryThread
   {
      public string strBuffer;        // Inter-thread buffer
      public INVOKE_ENUMREG itReason; // Inter-thread reason

      // Public thread to allow monitoring by UI thread.
      public Thread thrd = null;    // The contained thread
      private Control m_ctlInvokeTarget; // Inter-thread control
      private EventHandler m_deleCallback; // Inter-thread delegate
      
      // Private data.
      private bool m_bContinue;    // Continue flag.
      private bool m_bKeys;        // Enumerate keys or values
      private IntPtr m_hkeyRoot;  // Root enumeration key.
      private string m_strRegNode; // Root enumeration node.

      public bool bThreadContinue // Continue property.
      {
         get { return m_bContinue; }
         set { m_bContinue = value; }
      }

      public RapiEnumRegistryThread(
         Control ctl,          // Who to call.
         EventHandler dele,    // Notification delegate.
         bool bKeys,           // Enum keys or values.
         IntPtr hkeyRoot,     // Root of search.
         string strRegNode)    // Node to search.
      {
         // Make private copies of init data.
         m_ctlInvokeTarget = ctl;     
         m_deleCallback = dele;       
         m_bKeys = bKeys;           
         m_hkeyRoot = hkeyRoot;     
         m_strRegNode = strRegNode; 

         bThreadContinue = true;    
      }

      public bool Run()
      {
         ThreadStart ts = null;
         ts = new ThreadStart(ThreadMainEnumReg);
         if (ts == null)
            return false;

         thrd = new Thread(ts);
         thrd.Start();
         
         return true;
      }


      /// <summary>
      /// ThreadMainEnumReg - Enumerate registry values.
      /// </summary>
      private void ThreadMainEnumReg()
      {
         // Open registry key.
         IntPtr hkeySearchNode = IntPtr.Zero;
         int iResult = Rapi.CeRegOpenKeyEx(
            this.m_hkeyRoot, this.m_strRegNode, 
            0, 0, ref hkeySearchNode);
         if (iResult != Rapi.ERROR_SUCCESS && m_bContinue)
         {
            // Send error message.
            itReason = INVOKE_ENUMREG.STATUS_MESSAGE;
            strBuffer = "Error accessing registry key";
            this.m_ctlInvokeTarget.Invoke(m_deleCallback);

            // Trigger end of enumeration.
            itReason = INVOKE_ENUMREG.ENUMREG_ENDED;
            this.m_ctlInvokeTarget.Invoke(m_deleCallback);
            
            // Trigger that shutdown is complete.
            thrd = null;
            return;
         }

         // Keys or values?
         if (this.m_bKeys)  // Enumerate keys.
         {
            int iIndex = 0;
            while (iResult == Rapi.ERROR_SUCCESS && m_bContinue)
            {
               string strKeyName = new string('\0', 32);
               int cbLength = 32;
               iResult = Rapi.CeRegEnumKeyEx(
                  hkeySearchNode, iIndex++,
                  strKeyName, ref cbLength,
                  0, 0, 0, 0);
               if (iResult == Rapi.ERROR_SUCCESS && m_bContinue)
               {
                  itReason = INVOKE_ENUMREG.ENUMREG_NEWKEY;
                  strBuffer = strKeyName;
                  this.m_ctlInvokeTarget.Invoke(m_deleCallback);
               }
            } // while
         }
         else               // Enumerate values.
         {
            int iIndex;
            for (iIndex = 0; iResult == Rapi.ERROR_SUCCESS &&
                 m_bContinue; iIndex++)
            {
               int cbName = 32;
               string strName = new string('\0', 16);
               Rapi.REGTYPE iType = 0;
               int cbLength = 0;

               // Enumerate key names only (not values)
               iResult = Rapi.CeRegEnumValue(hkeySearchNode, 
                  iIndex, strName, ref cbName,
                  0, ref iType, IntPtr.Zero, 
                  ref cbLength);

               if (iResult == Rapi.ERROR_SUCCESS && m_bContinue)
               {
                  if (iType == Rapi.REGTYPE.REG_SZ) // string values.
                  {
                     int cbData=32;
                     string str = new string(new char[cbData]);
                     Rapi.CeRegQueryValueEx(hkeySearchNode,
                         strName, 0, ref iType, str, 
                         ref cbData);
                     char [] ach = {'\0'};
                     strBuffer = strName.Trim(ach) + " = "
                        + str.Trim(ach);
                  }
                  else if (iType == Rapi.REGTYPE.REG_BINARY)
                  {
                     // Fetch binary array of short values
                     char [] ach = {'\0'};
                     strBuffer = strName.Trim(ach) + " = ";
                     
                     // Allocate buffer of short values.
                     Int16 sh = 0;
                     IntPtr iptr;
                     int cbSizeOfShort = Marshal.SizeOf(sh);
                     int cbData =  cbSizeOfShort * 5;
                     iptr = Marshal.AllocCoTaskMem(cbData);

                     // Fetch array of short values.
                     Rapi.CeRegQueryValueEx(hkeySearchNode,
                        strName, 0, ref iType, iptr, 
                        ref cbData);

                     // Copy array to managed array.
                     int cElements = cbData / cbSizeOfShort;
                     Int16 [] ash = new Int16 [cElements];
                     Marshal.Copy(iptr, ash, 0, cElements);
                     Marshal.FreeCoTaskMem(iptr);

                     // Add values to string for display.
                     for (int i = 0; i < cElements; i++)
                     {
                        strBuffer = strBuffer + ash[i] + " ";
                     }
                  }
                  else
                  {
                     strBuffer = strName + " not expected type";
                  }
                  itReason = INVOKE_ENUMREG.ENUMREG_NEWVALUE;
                  this.m_ctlInvokeTarget.Invoke(m_deleCallback);
               }
            } // for
         } // if

         Rapi.CeRegCloseKey(hkeySearchNode);

         // Trigger end of enumeration.
         itReason = INVOKE_ENUMREG.ENUMREG_ENDED;
         this.m_ctlInvokeTarget.Invoke(m_deleCallback);

         // Trigger that shutdown is complete.
         thrd = null;
      } 
   } // class RapiEnumRegistryThread
} // namespace RegShowStartup
