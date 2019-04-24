//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace MyAddress
{
   /// <summary>
   /// Summary description for ptbox.
   /// </summary>
   public class PostalCodeTextBox : TextBox
   {
      public PostalCodeTextBox()
      {
         //
         // TODO: Add constructor logic here
         //
         this.TextChanged +=new EventHandler(PostalCodeTextBox_TextChanged);
      }

      //--------------------------------------------------------
      // Private fields for public properties
      private bool m_bAllowSpace = false;
      private bool m_bAllowLetters = false;

      //--------------------------------------------------------
      // Public Properties
      public bool AllowSpace
      {
         get
         { return m_bAllowSpace;    }
         set
         {  m_bAllowSpace = value;  }
      } // property: AllowSpace

      public bool AllowLetters
      {
         get
         { return m_bAllowLetters;    }
         set
         {  m_bAllowLetters = value;  }
      } // property: AllowLetters

      //--------------------------------------------------------
      // Override base class OnKeyPress event handler method.
      // Original definition
      // protected virtual void OnKeyPress(KeyPressEventArgs e);
      protected override void OnKeyPress(KeyPressEventArgs e)
      {
         bool bAllowChar = false;

         if ((Char.IsDigit(e.KeyChar)) ||
             (m_bAllowLetters && Char.IsLetter(e.KeyChar)) ||
             (m_bAllowSpace   && e.KeyChar.Equals(' ')) ||
             (Char.IsControl(e.KeyChar)))
         {
            bAllowChar = true;
         }
         
         if (bAllowChar)
         {
            // Process input.
            base.OnKeyPress(e);
         }
         else
         {
            // Ignore input by saying that we handled it.
            e.Handled = true;
         }
      } // method: OnKeyPress

      //--------------------------------------------------------
      // Change in text triggers PostalCodeChanged event
      // when valid postal code is seen. For now, correct
      // length is all that is needed.
      private void 
         PostalCodeTextBox_TextChanged(object sender, EventArgs e)
      {
         if (Text.Length == MaxLength)
         {
            OnPostalCodeChanged(EventArgs.Empty);
         }
      } // method: PostalCodeTextBox_TextChanged

      //--------------------------------------------------------
      // Field for collection of delegates 
      // to be called when event occurs.
      private EventHandler m_evPostalCodeChanged;

      //--------------------------------------------------------
      // Public event - manage delegate collection,
      // and expose event to outside world.
      public event EventHandler PostalCodeChanged 
      {
         add 
         {
            m_evPostalCodeChanged += value;
         }
         remove 
         {
            m_evPostalCodeChanged -= value;
         }
      }

      //--------------------------------------------------------
      // Our method for calling registered 
      protected virtual void 
      OnPostalCodeChanged(EventArgs e) 
      {
         if (m_evPostalCodeChanged != null) 
         {
            m_evPostalCodeChanged.Invoke(this, e);
         }
      } // method: OnPostalCodeChanged


   } // class
} // namespace
