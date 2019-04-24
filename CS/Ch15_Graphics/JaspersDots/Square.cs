// Square.cs - Elements of a game square.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.
using System;
using System.Drawing;

namespace JaspersDots
{
   public struct Square
   {
      // Coordinate of main rectangle.
      public Rectangle rcMain;
      public int iOwner;

      // Hit-rectangles of four edges of main rectangle.
      public Rectangle rcTop;
      public bool bTop;
      public Rectangle rcRight;
      public bool bRight;
      public Rectangle rcBottom;
      public bool bBottom;
      public Rectangle rcLeft;
      public bool bLeft;
   } // struct Square
}
