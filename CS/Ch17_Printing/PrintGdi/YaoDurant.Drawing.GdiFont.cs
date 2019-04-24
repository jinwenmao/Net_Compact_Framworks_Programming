// YaoDurant.Drawing.Font.cs - Supports the creation of 
// Win32 fonts.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Runtime.InteropServices;
using YaoDurant.Win32;

namespace YaoDurant.Drawing
{
   /// <summary>
   /// Summary description for YaoDurant.
   /// </summary>
   public class GdiFont
   {
      [DllImport("coredll.dll")]
      public static extern IntPtr CreateFontIndirect (IntPtr lplf);

      public const int LF_FACESIZE = 32;

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int GetTextMetrics (IntPtr hdc, ref TEXTMETRIC lptm);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int GetTextExtentExPoint (IntPtr hdc, 
         string lpszStr, int cchString, int nMaxExtent, ref int [] lpnFit, 
         ref int [] alpDx, ref System.Drawing.Size lpSize);

      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern int GetTextExtentExPoint (IntPtr hdc, 
         string lpszStr, int cchString, int Res1, int Res2, 
         int Res3, ref System.Drawing.Size lpSize);

      //--------------------------------------------------------
      // Create a Font for the display screen
      //--------------------------------------------------------
      public static IntPtr 
      Create(
         string strFace, 
         int iSize,
         int degrees)
      {
         // Calculate font height based on this ratio:
         // 
         //    Height in Pixels       Desired Point Size
         //  -------------------  =   ------------------
         //   Device Resolution              72
         //
         // (72 point = approx. 1 inch.)
         //
         // Which results in the following formula:
         //
         // Height = (Desired_Pt * Device_Res) / 72
         //
         IntPtr hdc = GdiGraphics.GetDC(IntPtr.Zero);
         IntPtr hfont = Create(strFace, iSize, degrees,hdc);
         GdiGraphics.ReleaseDC(IntPtr.Zero, hdc);
         return hfont;
         }

      //--------------------------------------------------------
      // Create a Font for a specific device
      //--------------------------------------------------------
      public static IntPtr 
         Create(
         string strFace, 
         int iSize,
         int degrees,
         IntPtr hdc)
      {
         int cyDevice_Res = GdiGraphics.GetDeviceCaps(hdc, CAPS.LOGPIXELSY);

         // Calculate font height.
         float flHeight = ((float)iSize * (float)cyDevice_Res) / 72.0F;
         int iHeight = (int)(flHeight + 0.5);

         // Set height negative to request "Em-Height" (versus
         // "character-cell height" for positive size)
         //iHeight = iHeight * (-1);

         // Allocate managed code logfont structure
         LOGFONT logfont = new LOGFONT();
         logfont.lfHeight = iHeight;
         logfont.lfWidth = 0;
         logfont.lfEscapement = degrees * 10;
         logfont.lfOrientation = 0;
         logfont.lfWeight = 0;
         logfont.lfItalic = 0;
         logfont.lfUnderline= 0;
         logfont.lfStrikeOut= 0;
         logfont.lfCharSet = 0;
         logfont.lfOutPrecision = 0;
         logfont.lfClipPrecision = 0;
         logfont.lfQuality = 0;
         logfont.lfPitchAndFamily = 0;

         // Allocate unmanaged code logfont structure.
         int cbLogFont = Marshal.SizeOf(logfont);
         int cbMem =  cbLogFont + LF_FACESIZE;
         IntPtr iptrLogFont = NativeHeap.LocalAlloc(NativeHeap.LPTR, cbMem);
         if (iptrLogFont == IntPtr.Zero)
            return IntPtr.Zero;

         // Copy managed structure to unmanaged buffer
         Marshal.StructureToPtr(logfont, iptrLogFont, false);
      
         // Set pointer to end of structure
         IntPtr ipFaceDest = (IntPtr)((int)iptrLogFont + cbLogFont);

         // Copy string to a character array.
         char [] achFace = strFace.ToCharArray(); 
         int cch = strFace.Length;

         // Copy facename to unmanaged buffer
         Marshal.Copy(achFace, 0, ipFaceDest, cch);

         return CreateFontIndirect(iptrLogFont);
      }
   } // class

      public struct LOGFONT
      {
         public int  lfHeight;
         public int  lfWidth;
         public int  lfEscapement;
         public int  lfOrientation;
         public int  lfWeight;
         public byte lfItalic;
         public byte lfUnderline;
         public byte lfStrikeOut;
         public byte lfCharSet;
         public byte lfOutPrecision;
         public byte lfClipPrecision;
         public byte lfQuality;
         public byte lfPitchAndFamily;
         //         public TCHAR [] lfFaceName;
      };

      public struct TEXTMETRIC
      {
         public int tmHeight;
         public int tmAscent;
         public int tmDescent;
         public int tmInternalLeading;
         public int tmExternalLeading;
         public int tmAveCharWidth;
         public int tmMaxCharWidth;
         public int tmWeight;
         public int tmOverhang;
         public int tmDigitizedAspectX;
         public int tmDigitizedAspectY;
         public byte tmFirstChar;
         public byte tmLastChar;
         public byte tmDefaultChar;
         public byte tmBreakChar;
         public byte tmItalic;
         public byte tmUnderlined;
         public byte tmStruckOut;
         public byte tmPitchAndFamily;
         public byte tmCharSet;
      };

} // namespace
