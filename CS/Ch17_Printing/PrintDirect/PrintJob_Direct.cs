// PrintJob_Direct.cs - Creates a print job by opening a port
// and sending output as a byte stream.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.IO;
using System.Windows.Forms;

namespace PrintDirect
{
   public class PrintJob_Direct
   {
      private const byte CR = 0x0a;
      private const byte LF = 0x0d;
      private const byte FF = 0x0c;
   
      //--------------------------------------------------------
      //--------------------------------------------------------
      public static void PrintText(TextBox textIn, string strPort)
      {
         // Strip baud rate from port name.
         if (strPort.StartsWith("COM1:")) strPort = "COM1:";

         // Open printer port.
         System.IO.FileStream fs;
         fs = new System.IO.FileStream(strPort, FileMode.Create);
         if (fs == null)
         {
            throw (new ApplicationException("Cannot open port."));
         }

         try
         {
            // Split input data into separate lines of text.
            char [] achNewLine = new char[] { '\n' };
            String [] astrSplit;
            astrSplit = textIn.Text.Split(achNewLine);
            
            // Calculate longest string in the document.
            int cchMax = 0;
            int cstr = astrSplit.Length;
            for (int i = 0; i < cstr; i++)
            {
               if (astrSplit[i].Length > cchMax)
                  cchMax = astrSplit[i].Length;
            }

            // Allocate conversion buffer.
            byte[] byteData = new Byte[cchMax];
            char[] chData = new Char[cchMax];
            System.Text.Encoder d;
            d = System.Text.Encoding.UTF8.GetEncoder();

            // Loop through list of strings.
            for (int i = 0; i < cstr; i++)
            {
               int cch = astrSplit[i].Length;
               if (cch > 0)
               {
                  chData = astrSplit[i].ToCharArray();

                  // Convert Unicode string to UTF-8 encoding.
                  d.GetBytes(chData, 0, cch, byteData, 0, true);

                  // Output bytes to printer.
                  fs.Write(byteData, 0, cch);
               }

               // Put a <CR> at line end.
               byte[] byteCrLf = new byte[] { CR };
               fs.Write(byteCrLf, 0, 1);
            }

            // Put a <FF> at the end of the document.
            byte[] byteFF = new byte[] { FF };
            fs.Write(byteFF, 0, 1);
         }
         finally
         {
            // Close file stream.
            fs.Close();
         }
      }

#region An alternative using native Win32 functions
#if false
      //--------------------------------------------------------
      //--------------------------------------------------------
      public static void PrintTextWin32(TextBox textIn)
      {
         IntPtr hPort;
         
         string strPort;
         // strPort = @"\\Server\HP5si_PCL";
         // strPort = @"COM1:";
         strPort = @"\My Documents\TextPrint.dat";

         hPort = WinIO.CreateFile(strPort,
            WinIO.ACCESS.WRITE, WinIO.FILE_SHARE.WRITE, 0,
            WinIO.FILE_ACTION.OPEN_ALWAYS, WinIO.FILE_ATTRIBUTE.NORMAL, 0);

         // ?? Need to call SetCommState to set baud rate, etc. ??
         if (hPort == WinIO.INVALID_FILE_HANDLE)
         {
            MessageBox.Show("Error opening port", "PrintDirect");
         }
         else
         {
         // Split input data into separate lines of text.
         char [] achNewLine = new char[] { '\n' };
         String [] astrSplit;
         astrSplit = textIn.Text.Split(achNewLine);
            
         int i;
         int cstr = astrSplit.Length;
            
         // Check for largest string in document.
         int cchMax = 0;
         for (i = 0; i < cstr; i++)
         {
            if (astrSplit[i].Length > cchMax)
               cchMax = astrSplit[i].Length;
         }
         cchMax = cchMax + 5;  // Add some padding.

         // Allocate conversion buffers.
         byte[] byteData = new Byte[cchMax];
         char[] chData = new Char[cchMax];
         int cbWritten = 0;
         System.Text.Encoder d = System.Text.Encoding.UTF8.GetEncoder();

         for (i = 0; i < cstr; i++)
         {
            int cch = astrSplit[i].Length;
            if (cch > 0)
            {
               //MessageBox.Show(i.ToString() + " " + astrSplit[i]);
               chData = astrSplit[i].ToCharArray();
               int charLen = d.GetBytes(chData, 0, cch, byteData, 0, true);
               WinIO.WriteFile(hPort, byteData, charLen, ref cbWritten, IntPtr.Zero);
            }

            // Put a <CR><LF> at the end of the line.
            byte[] byteCrLf = new byte[] { CR };
            WinIO.WriteFile(hPort, byteCrLf, 2, ref cbWritten, IntPtr.Zero);
         }
         // Put a <FF> at the end of the document.
         byte[] byteFF = new byte[] { 0x0c };
         WinIO.WriteFile(hPort, byteFF, 1, ref cbWritten, IntPtr.Zero);
         WinIO.CloseHandle(hPort);
      }

      }
#endif
#endregion

   } // class
} // namespace
