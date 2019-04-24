//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;

namespace YaoDurant.CFBook.Utilities
{
	/// <summary>
	/// Summary description for WaterMath.
	/// </summary>
	public class WaterMath
	{
      //  Constants
      private const double GALLONS_PER_FOOT = 7.48;
      private const int INCHES_PER_FOOT = 12;

      public static int GetVolume( double dblSquareFeet ) 
      {
         //  This version of GetVolume 
         //     assumes 1 inch of rain.
         return (int)(dblSquareFeet * 
            GALLONS_PER_FOOT / INCHES_PER_FOOT );
      }

      public static int GetVolume( double dblSquareFeet, 
         int intInches ) 
      {
         //  This version of GetVolume 
         //     accepts both roof size and rainfall.
         return (int)(dblSquareFeet * GALLONS_PER_FOOT * 
            intInches / INCHES_PER_FOOT);
      }
   }
}
