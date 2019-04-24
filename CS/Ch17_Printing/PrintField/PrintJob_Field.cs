// PrintJob_Field.cs - Print job handler for PrintField program,
// which demonstrates printing with rendering provided by the 
// PrintCF product from Field Software, Inc.
// http://www.fieldsoftware.com/PrinterCE_NetCF.htm
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FieldSoftware.PrinterCE_NetCF;

namespace PrintField
{
   public class PrintJob_Field
   {
      //--------------------------------------------------------
      //--------------------------------------------------------
      public static void PrintText(TextBox textIn, PrinterCE prce)
      {
         // Define drawing coordinates
         // Units are pixels
         prce.ScaleMode = PrinterCE.MEASUREMENT_UNITS.PIXELS;

         // Get device resolution
         double cxyInch = prce.PrinterResolution;

         // Set margins to 1-inch.
         prce.PrLeftMargin = cxyInch;
         prce.PrTopMargin = cxyInch;
         prce.PrRightMargin = cxyInch;
         prce.PrBottomMargin = cxyInch;

         // Calculate page size.
         double cxPhysPage = prce.PrPgWidth;
         double cyPhysPage = prce.PrPgHeight;

         // Calculate line height.
         // For timing tests, hard-code this value to
         // 46 for line height for 10 Point Courier New.
         double cyLineHeight = prce.GetStringHeight;

         // Init text drawing coordinates;
         double xText = 0;
         double yText = 0;

         // Calculate page boundaries
         double yFirst = yText;
         double yLast  = cyPhysPage;

         // Split input data into separate lines of text.
         char [] achNewLine = new char[] { '\n'};
         String [] astrSplit;
         astrSplit = textIn.Text.Split(achNewLine);

         // Check for longest string in the document
         int i;
         int cchMax = 0;
         int cstr = astrSplit.Length;
         for (i = 0; i < cstr; i++)
         {
            if (astrSplit[i].Length > cchMax)
               cchMax = astrSplit[i].Length;
         }

         // Set iEnd -- trim extra carriage-return from text
         int iEnd = 0;
         int cchString = astrSplit[0].Length;
         char ch = astrSplit[0][cchString-1];
         if (ch == '\r') iEnd = -1;

         // Loop on available strings.
         for (i = 0; i < cstr; i++)
         {
            cchString = astrSplit[i].Length;
            if (cchString > 0)
            {
               // Draw line of text.
               prce.DrawText(astrSplit[i], xText, yText, 
                  cchString + iEnd);
            }

            // Advance to next line.
            yText += cyLineHeight;

            // Skip to next page (if not at end of document)
            if (yText >= yLast && (i+1) < cstr)
            {
               prce.NewPage();
               yText = yFirst;
            }
         }

         // End of page & end of document.
         prce.EndDoc();

      } // PrintText()

   } // class
} // namespace
