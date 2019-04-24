// PrintJob_Socket.cs - Creates a print job by sending raw text
// to a printer identified by an IP address.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace PrintDirect
{
public class PrintJob_Socket
{
   private const byte CR = 0x0a;
   private const byte LF = 0x0d;
   private const byte FF = 0x0c;

   //--------------------------------------------------------
   //--------------------------------------------------------
   public static void PrintText(TextBox textIn, string strPort)
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

      Socket s = null;

      try
      {
         // Connect to printer.
         s = new Socket(AddressFamily.InterNetwork, 
            SocketType.Stream, ProtocolType.IP);
         IPAddress addr = IPAddress.Parse(strPort);
         IPEndPoint ipep = new IPEndPoint(addr, 9100);
         s.Connect(ipep);

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
               s.Send(byteData,0, cch,SocketFlags.None);
            }

            // Put a <CR> at line end.
            byte[] byteCrLf = new byte[] { CR };
            s.Send(byteCrLf,0, 1,SocketFlags.None);
         }

         // Put a <FF> at the end of the document.
         byte[] byteFF = new byte[] { FF };
         s.Send(byteFF,0, 1,SocketFlags.None);
      }
      finally
      {
         s.Close();
      }
   }

   //--------------------------------------------------------
   public static bool IsIPAddress(string strIn)
   {
      bool bRetVal = true;
      try
      {
         IPAddress.Parse(strIn);
      }
      catch
      {
         bRetVal = false;
      }

      return bRetVal;
   }

} // class
} // namespace
