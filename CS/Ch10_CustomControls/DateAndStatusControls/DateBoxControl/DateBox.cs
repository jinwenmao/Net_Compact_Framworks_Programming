//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace YaoDurant.Gui
{
   /// <summary>
   /// Summary description for DateBox.
   /// </summary>
   public class DateBox : TextBox 
   {
      #region Properties
      
      // Menu Text strings
      string[] astrMenu = {"Info", "Format", "SetMinMax"};
      string[] astrInfo = {"DayOfWeek: ", "Julian: "};
      string[] astrFormat = new string[7];
      string[] astrMinMax = 
                  {"Set minimum date","Set maximum date"};

      // SubMenu index values
      private enum MenuItemIndex
      { 
         miiInfo, miiFormat, miiMinMax
      }
      private enum MinMaxIndex
      { 
         miiMin, miiMax
      }

      // Date.  
      //    The date contained and displayed in this control.
      private bool boolSettingDate;
      private DateTime m_Date = DateTime.Today;
      public DateTime Date
      {
         get { return m_Date; }
         set 
         {
            // If the user has been inputting the Min or Max
            //    date, then store it in the appropriate
            //    property and restore the actual date.
            if( m_MinChanging )
            {
               m_MinValue = value;
               m_MinChanging = false;
               this.Date = this.Date;
               return;
            }
            if( m_MaxChanging )
            {
               m_MaxValue = value;
               m_MaxChanging = false;
               this.Date = this.Date;
               return;
            }

            // Set the private date.
            m_Date = value;

            // Set the Text property
            boolSettingDate = true;
            this.Text = m_Date.GetDateTimeFormats('d')[m_Format];
            boolSettingDate = false;

            // Set the background color to indicate whether 
            //    the date is within the user specified range
            //    or not.
            this.BackColor = Color.White;
            if( ! (m_MinValue <= m_Date && m_Date <= m_MaxValue))
            {
               this.BackColor = Color.Red;
            }
         }
      }

      //   Text
      public override string Text
      {
         get
         {
            return base.Text;
         }
         set
         {
            try
            {
               // There is no such thing as an "empty" date.
               //    No date means "today".
               if( value == String.Empty ) 
               {
                  value = DateTime.Today.ToShortDateString();
               }

               // To prevent an infinite loop...
               // If we are being called because the Date
               //    property is being set, do not set 
               //    the Date property.  Else, set the Date
               //    to keep it in synch with the Text property.
               if( boolSettingDate )
               {
                  base.Text = value;
               }
               else
               {
                  this.Date = Convert.ToDateTime(value);
               }
            }
            catch
            {
               // Unable to convert value to DateTime.
               // (Highly unlikely that "base.Text = value;" 
               //    would cause the exception.)
               throw new 
                  System.ArgumentException("Not a valid date");
            }
            finally
            {
            }
         }
      }

      // Min and Max dates.

      private bool m_MinChanging;
      private bool m_MaxChanging;

      private DateTime m_MinValue = DateTime.MinValue;
      public DateTime MinValue
      {
         get { return m_MinValue; }
         set 
         { 
            m_MinValue = value;
         }
      }

      private DateTime m_MaxValue = DateTime.MaxValue;
      public DateTime MaxValue
      {
         get { return m_MaxValue; }
         set 
         { 
            m_MaxValue = value;
         }
      }

      // Format.  
      //    An index into the GetDateTimeFormats('d') array.
      private int m_Format;
      public int Format
      {
         get { return m_Format; }
         set 
         { 
            // Set the format.
            m_Format = value;
            
            // Force it to take effect.
            this.Date = this.Date;
         }
      }

      #endregion

      #region Initialization and Termination

      public DateBox()
      {
         // Initialize Date and Format.
         this.Date = DateTime.Today;
         this.Format = 6;
         // Just offer the first 7, of 131 possible, date formats.
         Array.Copy(
            DateTime.Today.GetDateTimeFormats(), 0,
            astrFormat, 0, 
            7);

         // Set initial size
         this.Width = (int)this.Font.Size * 8;

         // Create the ContextMenu
         this.ContextMenu = this.BuildContextMenu();

         // Handle own Validating/Validated events.
         // Note.  Cannot override OnValidated as it is  
         //    "inherited but not implemented" in 
         //    CompactFramework.
         this.Validating += 
            new CancelEventHandler(this.this_Validating);
      }

      #endregion

      #region Base Class Overrides

      private void this_Validating(object sender, 
                                   CancelEventArgs e)
      {
         // Ensure that the Text property contains a date,
         //    and that that date lies within the MinDate 
         //    to MaxDate range.
         // If test fails, set background color to red and
         //    set the EventArg's Cancel property to true
         //    to indicate that validation failed.
         try
         {
            this.Text = this.Text;
         }
         catch
         {
            this.BackColor = Color.Red;
            e.Cancel = true;
         }
         finally
         {
         }
      }
      #endregion

      #region Menu Handlers and Utilities
      
      private ContextMenu BuildContextMenu()
      {
         // Build the context menu for this class.
         MenuItem miWork;
         MenuItem miWork2;
         ContextMenu cmenuThis = new ContextMenu();

         // Sub menu - GeneralInfo
         //    Menu items for this submenu do not need a 
         //    handler, they are just informational entries
         //    such as the Day-of-Week that are completed
         //    as the context menu is being presented.
         miWork = new MenuItem();
         miWork.Text = astrMenu[0];

         miWork.MenuItems.Add(new MenuItem());
         miWork.MenuItems.Add(new MenuItem());
         cmenuThis.MenuItems.Add(miWork);

         // Sub menu - Formats
         //    Use GetDateTimeFormats('d') to 
         //    get the possible formats.
         miWork = new MenuItem();
         miWork.Text = astrMenu[1];
         foreach(string dateFormat in astrFormat)
         {
            miWork2 = new MenuItem();
            miWork2.Text = dateFormat;
            miWork2.Click += 
               new System.EventHandler(this.mnuFormat_Click);
            miWork.MenuItems.Add(miWork2);
         }
         cmenuThis.MenuItems.Add(miWork);

         // Sub menu - MinMax
         miWork = new MenuItem();
         miWork.Text = astrMenu[2];

         miWork2 = new MenuItem();
         miWork2.Text = astrMinMax[0];
         miWork2.Click += 
            new System.EventHandler(this.mnuMinMax_Click);
         miWork.MenuItems.Add(miWork2);

         miWork2 = new MenuItem();
         miWork2.Text = astrMinMax[1];
         miWork2.Click += 
            new System.EventHandler(this.mnuMinMax_Click);
         miWork.MenuItems.Add(miWork2);
         cmenuThis.MenuItems.Add(miWork);

         // Some entries are dynamic.  Need to handle 
         //    the Popup event for this ContextMenu.
         cmenuThis.Popup += 
            new EventHandler(ContextMenu_Popup);

         // Done
         return cmenuThis;
      }

      private void ContextMenu_Popup(object sender, EventArgs e)
      {
         // Fill in the "Info" SubMenu menu items.
         MenuItem miWork = 
            this.ContextMenu.MenuItems
            [(int)MenuItemIndex.miiInfo];
         miWork.MenuItems[0].Text = 
            "DayOfWeek: " + this.m_Date.DayOfWeek;    
         miWork.MenuItems[1].Text = 
            "Julian: " + this.m_Date.DayOfYear; 
      }

      private void mnuFormat_Click(object sender, 
         System.EventArgs e)
      {
         // The Format property of this control is an index
         //    into the arry of formats, astrFormat.  The
         //    user has selected the format string from the
         //    context menu; we must find that string within
         //    the array and set the property to the string's
         //    index within the array.
         this.Format = 
            Array.IndexOf(astrFormat,
            ((MenuItem)sender).Text, 0,
            astrFormat.GetLength(0)-1);
      }

      private void mnuMinMax_Click(object sender, 
         System.EventArgs e)
      {
         // To set the Min or Max allowable date, the user
         //    must use this control to do so.  Therefore,
         //    we must save the current date and set a 
         //    switch to indicate that we are in "MinMax
         //    change" mode.
         // Once the user has completed specifying the 
         //    Min or Max date, we will set the MinMix
         //    Date and restore the origional date.  This
         //    will be done in the Date property.

         switch( Array.IndexOf( astrMinMax,
                                ((MenuItem)sender).Text,
                                0,
                                astrMinMax.GetLength(0)-1) )
         {
            case (int)MinMaxIndex.miiMin:
               m_MinChanging = true;
               break;
            case (int)MinMaxIndex.miiMax:
               m_MaxChanging = true;
               break;
         }
         this.BackColor = Color.LightSlateGray;
         this.Text = string.Empty;
         this.Focus();
      }
      #endregion

   }
}
