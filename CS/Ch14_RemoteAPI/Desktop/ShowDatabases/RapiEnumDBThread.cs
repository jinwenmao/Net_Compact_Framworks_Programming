// RapiEnumDBThread.cs - Creates a background 
// thread to names of database volumes and names of databases
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using YaoDurant.Win32;

namespace ShowDatabases
{
   // Reasons our thread invokes user-interface thread.
   public enum INVOKE_ENUMDB
   {
      ENUMDB_NEWVOLUME,
      ENUMDB_NEWDATABASE,
      ENUMDB_COMPLETE,
      STATUS_MESSAGE
   }

   /// <summary>
   /// Summary description for RapiEnumDBThread.
   /// </summary>
   public class RapiEnumDBThread
   {
      public string strBuffer;       // Inter-thread buffer
      public INVOKE_ENUMDB itReason;   // Inter-thread reason

      private Thread m_thrd = null;    // The contained thread
      private Control m_ctlInvokeTarget; // Inter-thread control
      private EventHandler m_deleCallback; // Inter-thread delegate
      private bool m_bContinue; // Continue flag.
      private bool m_bVolume;   // Enum volumes or databases?

      public bool bThreadContinue // Continue property.
      {
         get { return m_bContinue; }
         set { m_bContinue = value; } 
      }

      public RapiEnumDBThread(Control ctl, EventHandler dele,
         bool bVolume)
      {
         m_bContinue = true;
         m_ctlInvokeTarget = ctl;  // Who to call.
         m_deleCallback = dele;    // How to call.
         m_bVolume = bVolume;
      }
      /// <summary>
      /// Run - Init function for enum thread.
      /// </summary>
      /// <param name="bSubDirs"></param>
      /// <returns></returns>
      public bool Run()
      {
         ThreadStart ts = null;
         ts = new ThreadStart(ThreadMainEnumDB);
         if (ts == null)
            return false;

         m_thrd = new Thread(ts);
         m_thrd.Start();
         return true;
      }

      private void ThreadMainEnumDB()
      {
         if (m_bVolume)  // Enumerate volumes.
         {
            Guid guid = new Guid("ffffffffffffffffffffffffffffffff");
            int cch = 32;
            string str = new String('\0', cch);
            while (Rapi.CeEnumDBVolumes(ref guid, str, cch) == 
               Rapi.RAPI_TRUE && m_bContinue)
            {
               strBuffer = str;
               itReason = INVOKE_ENUMDB.ENUMDB_NEWVOLUME;
               m_ctlInvokeTarget.Invoke(m_deleCallback);
            }
         }
         else            // Enumerate databases.
         {
            short cRecords = 0;
            IntPtr pfdbAll = IntPtr.Zero;
            Rapi.CeFindAllDatabases(0, 
               Rapi.FAD.FAD_NAME | Rapi.FAD.FAD_NUM_RECORDS,
               ref cRecords, 
               ref pfdbAll);

            IntPtr pfdb = pfdbAll;
            while (cRecords > 0)
            {
               // Set pointer to next record.
               Rapi.CEDB_FIND_DATA dbfd = 
                  (Rapi.CEDB_FIND_DATA)
                  Marshal.PtrToStructure(
                     pfdb, typeof(Rapi.CEDB_FIND_DATA));

               // Post name to listbox.
               strBuffer = dbfd.DbInfo.szDbaseName + " (" +
                  dbfd.DbInfo.wNumRecords + " records)";
               itReason = INVOKE_ENUMDB.ENUMDB_NEWDATABASE;
               m_ctlInvokeTarget.Invoke(m_deleCallback);

               // Get ready for next loop.
               pfdb = (IntPtr)((int)pfdb + Marshal.SizeOf(dbfd));
               cRecords--;
            } // while

            // Free memory returned by CeFindAllDatabases.
            Rapi.CeRapiFreeBuffer(pfdbAll);
         } // if
         
         // Notify main thread that we are done.
         itReason = INVOKE_ENUMDB.ENUMDB_COMPLETE;
         m_ctlInvokeTarget.Invoke(m_deleCallback);

         // Mark thread as done.
         m_thrd = null;
      }

   } // RapiEnumDBThread
} // ShowDatabases
