//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Text;

namespace YaoDurant.Types
{
   /// <summary>
   /// Summary description for WaterTemp.
   ///   Consists of integer Temperature and a one character
   ///      long Unit of Measure; K, F, or C (Kelvin, Farhenheit,
   ///      Celsius).
   ///   Has an overloaded constructor that accepts a string.
   ///   Has ToString, CompareTo, Clone and Convert methods.
   /// </summary>
   public class WaterTemp
   {
      #region Properties

      private string strError;
      private string strerrFormat = 
         "Argument is not a valid water temperature.  Must " +
         "be a positive integer followed by 'C', 'F', or 'K'.";
      private string strerrUofM = 
         "Argument is not a valid unit of measure.  " +
         "Must be 'C', 'F', or 'K'.";
      private string strerrTemp =
         "Temperature must be greater than absolute 0.";

      private int m_Temperature;
      public int Temperature
      {
         get { return m_Temperature; }
      }

      private string m_UnitOfMeasure;
      public string UnitOfMeasure
      {
         get { return m_UnitOfMeasure; }
      }

      #endregion

      #region Contructors

      public WaterTemp()
      {
         InitializeWaterTemp(string.Empty);
      }

      public WaterTemp( string strTemp )
      {
         InitializeWaterTemp(strTemp);
      }

      public void InitializeWaterTemp( string strTemp )
      {
         // Convert a string, eg. " -44 c ", to a
         //    temperature and a unit of measure.
         
         // An empty string produces a cold WaterTemp.!
         if( strTemp == string.Empty )
         {
            strTemp = "0k";
         }

         // The last character, optional, is the Unit of
         //    Measure.  Everything else is the Temperature.
         strError = strerrFormat;
         try
         {
            // Split the input string on 'K', 'C', or 'F'.
            string[] strarrTemp;
            strTemp = strTemp.Trim().ToUpper();
            strarrTemp = strTemp.Split("KCF".ToCharArray());

            // Store the temperature portion.  (If any letter
            //    other than K/C/F was specified as the UofM,
            //    it will be in strarrTemp[0] and will cause
            //    an exception here.)
            this.m_Temperature = 
               System.Convert.ToInt32(strarrTemp[0]);
            
            // The UofM, if any, is the last character.
            // The default UofM is 'K' (Kelvin).
            this.m_UnitOfMeasure = 
               strarrTemp.Length == 2 ?
               strTemp.Substring(strTemp.Length-1,1) : "K";

            strError = strerrTemp;
            // Temperature cannot be below 0 Kelvin.
            // (Do not use Convert here.  Farhenheit prescision
            //    will be lost when converting to/from Kelvin.)
            strError = "Temperature cannot be below 0 Kelvin.";
            if( (m_UnitOfMeasure == "K" && m_Temperature < 0)
               ||(m_UnitOfMeasure == "C" && m_Temperature < -273)
               ||(m_UnitOfMeasure == "F" && m_Temperature < -460)
               )
            {
               throw new ArgumentException(strError);
            }
         }
         catch
         {
            throw new ArgumentException(strError);
         }
         finally
         {
         }
      }
      #endregion

      #region Methods

      public WaterTemp Convert( string strUofM )
      {
         strUofM = strUofM.ToUpper();
         int intTemp = m_Temperature;

         switch( strUofM )
         {
            case "K":
            switch( m_UnitOfMeasure )
            {
               case "F":
                  intTemp = 
                     (((intTemp + 40) * 5) / 9) - 40;
                  intTemp += 273;
                  break;
               case "C":
                  intTemp += 273;
                  break;
            }
               break;
            case "C":
            switch( m_UnitOfMeasure )
            {
               case "K":
                  intTemp -= 273;
                  break;
               case "F":
                  intTemp = 
                     (((intTemp + 40) * 5) / 9) - 40;
                  break;
            }
               break;
            case "F":
            switch( m_UnitOfMeasure )
            {
               case "K":
                  intTemp -= 273;
                  intTemp = 
                     (((intTemp + 40) * 9) / 5) - 40;
                  break;
               case "C":
                  intTemp = 
                     (((intTemp + 40) * 9) / 5) - 40;
                  break;
            }
               break;
            default:
               throw new ArgumentException(strerrUofM);
         }

         return new WaterTemp(intTemp.ToString() + strUofM);
      }

      public int CompareTo(WaterTemp wtTarget)
      {
         // If you and the target are the 
         //    same UofM, compare temperatures.
         // Otherwise, convert yourself to the
         //    other's UofM and compare temperatures.  
         if( this.UnitOfMeasure == wtTarget.UnitOfMeasure  )
         {
            return 
               m_Temperature.CompareTo(wtTarget.Temperature);
         }
         else
         {
            return 
               m_Temperature.CompareTo(
                  wtTarget.Convert(m_UnitOfMeasure).Temperature);
         }
      }

      public override string ToString()
      {
         return m_Temperature.ToString() + m_UnitOfMeasure;
      }

      public WaterTemp Clone()
      {
         return new WaterTemp(this.ToString());
      }

      #endregion

   }
}
