// TextEventSpy.cs - Generates events for keyboard events in the
// KeyInput sample.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Collections;
using System.Windows.Forms;

namespace KeyInput
{
   /// <summary>
   /// Summary description for TextEventSpy.
   /// </summary>
   public enum EventType
   {
      Event_KeyDown,
      Event_KeyPress,
      Event_KeyUp,
      Event_GotFocus,
      Event_LostFocus
   }

   // Buffer for passing event info to form.
   public struct KeyEventItem
   {
      public EventType etype;
      public KeyEventArgs eUpDown;
      public KeyPressEventArgs ePress;
   }

   /// <summary>
   /// Summary description for TextEventSpy.
   /// </summary>
   public class TextEventSpy : System.Windows.Forms.TextBox
   {
      private KeyEventItem m_kei = new KeyEventItem();
      private Control m_ctrlInvokeTarget; // Inter-thread control
      private EventHandler m_deleCallback; // Inter-thread delegate

      public KeyEventItem kei
      {
         get { return m_kei; }
      }

      public TextEventSpy(Control ctrl, EventHandler dele)
      {
         m_ctrlInvokeTarget = ctrl;  // Who to call.
         m_deleCallback = dele;    // How to call.
      }
      
      protected override void 
      OnKeyDown(KeyEventArgs e)
      {
         // Add new event info to list.
         m_kei.etype = EventType.Event_KeyDown;
         m_kei.eUpDown = e;

         // Trigger "new event" notification
         m_ctrlInvokeTarget.Invoke(m_deleCallback);

         base.OnKeyDown(e);
      }

      protected override void 
      OnKeyPress(KeyPressEventArgs e)
      {
         // Add new event info to list.
         m_kei.etype = EventType.Event_KeyPress;
         m_kei.ePress = e;

         // Trigger "new event" notification
         m_ctrlInvokeTarget.Invoke(m_deleCallback);

         base.OnKeyPress(e);
      }

      protected override void 
      OnKeyUp(KeyEventArgs e)
      {
         // Add new event info to list.
         m_kei.etype = EventType.Event_KeyUp;
         m_kei.eUpDown = e;

         // Trigger "new event" notification
         m_ctrlInvokeTarget.Invoke(m_deleCallback);

         base.OnKeyUp(e);
      }

      protected override void 
      OnGotFocus(EventArgs e)
      {
         // Add new event info to list.
         m_kei.etype = EventType.Event_GotFocus;

         // Trigger "new event" notification
         m_ctrlInvokeTarget.Invoke(m_deleCallback);

         base.OnGotFocus(e);
      }

      protected override void 
      OnLostFocus(EventArgs e)
      {
         // Add new event info to list.
         m_kei.etype = EventType.Event_LostFocus;

         // Trigger "new event" notification
         m_ctrlInvokeTarget.Invoke(m_deleCallback);

         base.OnLostFocus(e);
      }

   }
}
