//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Threading;

namespace MultiThreadedCS
{
	/// <summary>
	/// Summary description for GetDataWrapper.
	/// </summary>

   // GetDataWrapper class.  A wrapper around a thread that
   //    simulates a component, or other service, contacting
   //    a WebService, receiving a DataSet, and delivering 
   //    that DataSet back to the calling Control via a 
   //    callback routine.
   // Since all Compact Framework delegates must be of type
   //    EventHandler; that is, they must be:
   //       public void XXX (object sender, EventArgs e)
   //    and since EventArgs holds no information, data is 
   //    passed between the calling Control and this object
   //    by placing it within a Queue object that is created
   //    by the calling Control and passed to this object in
   //    this object's overloaded constructor.

   public class GetDataWrapper
	{
      // Data passed in the constructor
      //    by the caller.  Stored here.
      private Control formCaller;
      private EventHandler deleCallback;
      private Queue queueArgs;

      // The class's thread.
      private Thread thrdGetData;

      // The call can request that the thread terminate.
      bool TerminateRequestReceived = false;

      // The only constructor.  Takes three parameters.
      public GetDataWrapper
         ( 
         // Location of delegate.  Could
         //    be a control or a form.
         Control formCaller,  
         
         // The delegate to invoke after the data has 
         //    been gathered.
         EventHandler deleCallback,  

         // Since EventHandler is the only possible
         //    delegate type allowed in CF, and since it
         //    does NOT allow for the passing of parameters
         //    other than "sender" and "EventArg.Empty",
         //    the caller will provide a queue for use by
         //    this class in passing the DataSet back to 
         //    the caller
         Queue queueArgs 
         )
      {
         // Save the input params.
         this.formCaller = formCaller;
         this.deleCallback = deleCallback;
         this.queueArgs = queueArgs;

         // Create and start the thread.
         thrdGetData = new Thread(new ThreadStart( ThreadProc ));
         thrdGetData.Start();
      }

      private void ThreadProc()
      {
         // Simulate contacting a Web Service and receiving
         //    a returned DataSet object.  In this example,
         //    we'll simply create and load the DataSet here.
         // The DataSet will contain one DataTable which will
         //    contain one row which will contain a person's
         //    first name and last name.
         DataTable dtblPerson = new DataTable("Person");;

         dtblPerson.Columns.Add
            ("FirstName", Type.GetType("System.String"));
         dtblPerson.Columns.Add
            ("LastName", Type.GetType("System.String"));
         dtblPerson.Rows.Add
            (new System.String[2] {"Marion","Shank"});

         DataSet dsetPerson = new DataSet("Person");
         dsetPerson.Tables.Add(dtblPerson);

         // In CompactFramework there is no Thread.Stop, or
         //    comparable, method.  We stop by reaching the
         //    end of the ThreadProc ASAP.  
         if( ! TerminateRequestReceived )
         {
            // Now that we have our dataset, we need to pass
            //    it back to the caller.  Since we are using
            //    Invoke to communicate with the calling form,
            //    we cannot pass the DataSet in a parameter,
            //    for CompactFramework's Invoke does not allow
            //    parameters.  Instead, the form has provided
            //    us with a System.Collections.Queue object
            //    for us to use.  We'll place the dataset into
            //    a Queue and let the Invoked routine retrieve
            //    it from the queue.
            lock(this.queueArgs.SyncRoot)
            {
               this.queueArgs.Enqueue(dsetPerson);
            }
            this.formCaller.Invoke(this.deleCallback);
            // Placing the above line of code inside the
            //    lock loop would ensure that only one 
            //    object was in the queue when the callback
            //    executed, thus making the callback 
            //    routine simplier to write; but it would
            //    result in a lock of greater granularity.
         }
      }

      private void Stop()
      {
         TerminateRequestReceived = true;
      }
   }
}
