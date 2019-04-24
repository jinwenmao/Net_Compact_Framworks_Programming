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
using YaoDurant.Types;

namespace YaoDurant.Gui
{
	/// <summary>
	/// Summary description for WaterBox.
	/// </summary>
	public class WaterBox : TextBox
	{
      #region Properties
      
      // Temperature.  
      //    The WaterTemp contained and displayed 
      //       in this control.
      private bool boolSettingTemperature;
      private WaterTemp m_Temperature;
      public WaterTemp Temperature
      {
         get { return m_Temperature; }
         set 
         {
            // Set the private Temperature.
            m_Temperature = value;

            // Set the Text property
            boolSettingTemperature = true;
            this.Text = m_Temperature.ToString();
            boolSettingTemperature = false;

            // Set the background color to 
            //    indicate ice / water / steam.
            this.BackColor = Color.White;
            if( m_Temperature.CompareTo(new WaterTemp("0c")) == -1)
            {
               this.BackColor = Color.LightSteelBlue;
            }
            if( m_Temperature.CompareTo(new WaterTemp("100c")) == 1)
            {
               this.BackColor = Color.LightPink;
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
               // There is no such thing as an "empty" 
               //    Temperature.  No Temperature means 
               //    zero digrees Kelvin.
               if( value == String.Empty ) 
               {
                  value = "0k";
               }

               // To prevent an infinite loop...
               // If we are being called because the 
               //    Temperature property is being set, 
               //    do not set the Temperature property.  
               //    Else, set the Temperature to keep it 
               //    in synch with the Text property.
               if( boolSettingTemperature )
               {
                  base.Text = value;
               }
               else
               {
                  this.Temperature = new WaterTemp(value);
               }
            }
            catch
            {
               // Unable to convert value to WaterTemp.
               // (Highly unlikely that "base.Text = value;" 
               //    would cause the exception.)
               throw new 
                  System.ArgumentException(
                                 "Not a valid Temperature");
            }
            finally
            {
            }
         }
      }

      #endregion
      
      #region Initialization and Termination

      public WaterBox()
      {
         // Initialize Temperature.
         this.Temperature = new WaterTemp("0k");

         // Initialize remainder of this control.
         InitializeWaterBox();
      }

      public WaterBox(string strTemp)
      {
         // Initialize Temperature.
         this.Temperature = new WaterTemp(strTemp);

         // Initialize remainder of this control.
         InitializeWaterBox();
      }

      private void InitializeWaterBox()
      {
         // Handle own Validating events.
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
         // Ensure that the Text property contains a Temperature.
         // If not, set background color to red and set the 
         //    EventArg's Cancel property to true to indicate 
         //    that validation failed.
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
   }
}
