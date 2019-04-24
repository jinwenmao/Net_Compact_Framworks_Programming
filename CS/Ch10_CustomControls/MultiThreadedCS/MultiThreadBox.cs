//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.ComponentModel;
using MultiThreadedCS;

namespace YaoDurant.Gui
{
	/// <summary>
	/// Summary description for MultiThreadBox.
	/// </summary>

   // Note:
   // This control imposes a restriction on the service
   //    theads that provide it information, be
   //    they threads of code that resides in this 
   //    namespace, or threads whose thread proc was
   //    defined in some component outside this namespace.
   // This restriction is "real world" and should be
   //    imposed by all forms/controls that receive data
   //    threads other than their main thread.  It is: 
   //    The service thread must use Invoke to call the
   //    control's method.  
   // This ensures that calling of the control's method 
   //    runs on the correct thread and is properly 
   //    synchronized.  This should be a requirement 
   //    in all applications.  Do not be deceived by 
   //    the fact that, in this simple app running
   //    in a simple execution environment, the call
   //       this.formCaller.Invoke(this.deleCallback);
   //    could be replaced by 
   //       this.deleCallback(this.formCaller,EventArgs.Empty);
   //    The latter offers no benefit, and will not run
   //    properly under all conditions.  Always use Invoke.
   
   public class MultiThreadBox : TextBox
	{
      private Queue qPassData;
      private EventHandler deleReceiveData;

      public MultiThreadBox()
		{
         // Create a System.Collections.Queue to be used by
         //    the service threads to pass data bask to the
         //    this control.
         qPassData = new Queue();

         // The delegate to the form's method that will be
         //    invoked by the service threads.
         deleReceiveData = new EventHandler(this.ReceiveData);
      }

      public void RequestData()
      {
         // Create a GetDataWrapper object.  The object will
         //    Create and start a thread.  The thread will get
         //    a dataset, place it into qPassData, and then
         //    invoke ReceiveData via a delegate.
         GetDataWrapper refGetData = 
            new GetDataWrapper( this, deleReceiveData ,qPassData );
      }

      private void ReceiveData(object s, System.EventArgs e)
      {
         // Retrieve the dataset that was placed into qPassData
         //    by the service thread and display it in controls.

         // In our app there will only one object in the queue
         //    when this routine is Invoked because we only 
         //    have one service thread running.  Because of
         //    this, the code below could be simplier, 
         //    replacing the while loop with a call to 
         //    Dequeue.  But we wanted to illustrate the 
         //    code needed for the more "real world" 
         //    situation, in which multiple threads might have 
         //    placed multiple objects in the queue.
         DataSet dsetPerson;
         IEnumerator queueEnumerator = qPassData.GetEnumerator();

         // Enumerate through all the 
         //    DataSets that are in the queue.
         while( queueEnumerator.MoveNext() )
         {
            dsetPerson = (DataSet)(queueEnumerator.Current);
            // Move the DataSet contents into the Text property.
            this.Text = dsetPerson.Tables[0].Rows[0]
                                       ["FirstName"].ToString()
                      + " "
                      + dsetPerson.Tables[0].Rows[0]
                                       ["LastName"].ToString();
         }
      }
   }
}
