//-----------------------------------------------------------------------------
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeGame
{
	/// <summary>
	/// Summary description for utilGUI.
	/// </summary>
	public class utilGUI
	{
		public utilGUI()
		{
			//
			// TODO: Add constructor logic here
			//
		}

      // Symbolic constants for menu selections.
      public enum gameSpeed
      {
         gsSlowest = 2046, gsSlow = 1024, gsSlower = 512, 
         gsNormal = 256, 
         gsFaster = 128, gsFast = 64, gsFastest = 32
      }
      public enum gameZoom 
      {
         gzInnest = 8, gzIn = 16, gzInner = 16, 
         gzNormal = 32, 
         gzOuter = 64, gzOut = 64, gzOutest = 128
      }

      // Replaces a desktop method that is not
      //     available in Compact Framework.
      internal static void SetBounds(Control theControl,
                                     int x, int y, 
                                     int width, int height)
      {
         theControl.Left = x;
         theControl.Top = y;
         theControl.Width = width;
         theControl.Height = height;
      }

	}
}
