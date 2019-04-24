// PrintJob_Gdi.cs - Creates a print job by creating a DC
// and calling GDI drawing calls.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using YaoDurant.Win32;
using YaoDurant.Drawing;

namespace PrintHPMobile
{
   public class PrintJob_Gdi
   {
      //--------------------------------------------------------
      public static void PrintText(TextBox textIn, IntPtr hdc)
      {
         // Split input data into separate lines of text.
         char [] achNewLine = new char[] { '\n'};
         String [] astrSplit;
         astrSplit = textIn.Text.Split(achNewLine);

         // Calculate longest string in the document
         int cchMax = 0;
         int cstr = astrSplit.Length;
         for (int i = 0; i < cstr; i++)
         {
            if (astrSplit[i].Length > cchMax)
               cchMax = astrSplit[i].Length;
         }

         // Allocate conversion buffers.
         byte[] byteData = new Byte[cchMax];
         char[] chData = new Char[cchMax];
         System.Text.Encoder d;
         d = System.Text.Encoding.UTF8.GetEncoder();

         // Get device resolution
         int cxyInch =
            GdiGraphics.GetDeviceCaps(hdc, CAPS.LOGPIXELSY);
         // In draft mode, the PCL driver returns wrong value.
         if (cxyInch == 0) 
         { 
            cxyInch = 150; 
         }

         // Calculate page size.
         int cxPhysPage =
            GdiGraphics.GetDeviceCaps(hdc, CAPS.PHYSICALWIDTH);
         int cyPhysPage = 
            GdiGraphics.GetDeviceCaps(hdc, CAPS.PHYSICALHEIGHT);
         int cxOff = 
            GdiGraphics.GetDeviceCaps(hdc, CAPS.PHYSICALOFFSETX);
         int cyOff = 
            GdiGraphics.GetDeviceCaps(hdc, CAPS.PHYSICALOFFSETY);

         // Calculate line height.
         TEXTMETRIC tm = new TEXTMETRIC();
         GdiFont.GetTextMetrics(hdc, ref tm);
         int cyLineHeight = tm.tmHeight + tm.tmExternalLeading;

         // Init text drawing coordinates;
         int xText = cxyInch - cxOff;
         int yText = cxyInch - cyOff;

         // Calculate page boundaries
         int yFirst = yText;
         int yLast  = cyPhysPage - cxyInch;

         // Notify GDI of document and page start.
         DOCINFO di = new DOCINFO();
         di.cbSize = Marshal.SizeOf(di);
         Printing.StartDoc(hdc, ref di);
         Printing.StartPage(hdc);

         try
         {
            // Set iEnd -- trim extra carriage-return from text
            int iEnd = 0;
            int cchString = astrSplit[0].Length;
            char ch = astrSplit[0][cchString-1];
            if (ch == '\r') iEnd = -1;

            // Loop through list of strings.
            for (int i = 0; i < cstr; i++)
            {
               cchString = astrSplit[i].Length;
               if (cchString > 0)
               {
                  // Draw line of text.
                  GdiGraphics.ExtTextOut(hdc, xText, yText, 0,
                     IntPtr.Zero, astrSplit[i], cchString + iEnd,
                     IntPtr.Zero);
               }

               // Advance to next line.
               yText += cyLineHeight;

               // Skip to next page (if not at document end)
               if (yText >= yLast && (i+1) < cstr)
               {
                  Printing.EndPage(hdc);
                  Printing.StartPage(hdc);
                  yText = yFirst;
               }
            }
         }
         finally
         {
            // End of page & end of document.
            Printing.EndPage(hdc);
            Printing.EndDoc(hdc);
         }

      } // PrintText()

   } // class
} // namespace
