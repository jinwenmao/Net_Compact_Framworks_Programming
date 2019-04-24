// YaoDurant.Drawing.CreateFont.cs - Wrapper for creating a 
// Win32 font
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Runtime.InteropServices;
using YaoDurant.Drawing;
using YaoDurant.Win32;

namespace YaoDurant.Drawing
{
   /// <summary>
   /// Summary description for YaoDurant.
   /// </summary>
   public class GdiFont
   {
      //
      // Text metric helper function & data structure.
      //
      [DllImport("coredll.dll", CharSet=CharSet.Unicode)]
      public static extern 
      int GetTextMetrics (IntPtr hdc, ref TEXTMETRIC lptm);

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

      [DllImport("coredll.dll")]
      public static extern 
      IntPtr CreateFontIndirect (IntPtr lplf);

      // The logical font structure -- minus the face name.
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

      public const int LF_FACESIZE = 32;

      //--------------------------------------------------------
      //--------------------------------------------------------
      public static IntPtr 
      Create(
         IntPtr hdcDevice,
         string strFace, 
         float sinSize,
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
         IntPtr hfont = IntPtr.Zero;

         float sinDevice_Res;
         sinDevice_Res = (float)GdiGraphics.GetDeviceCaps(
            hdcDevice, GdiGraphics.LOGPIXELSY);

         // Calculate font height.
         float flHeight = (sinSize * sinDevice_Res) / 72.0F;
         int iHeight = (int)(flHeight + 0.5);

         // Set height negative to request "Em-Height" (versus
         // "character-cell height" for positive size)
         iHeight = iHeight * (-1);

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
         IntPtr iptrLogFont = NativeHeap.LocalAlloc(
            NativeHeap.LPTR, cbMem);
         if (iptrLogFont == IntPtr.Zero)
            return IntPtr.Zero;

         // Copy managed structure to unmanaged buffer
         Marshal.StructureToPtr(logfont, iptrLogFont, false);

         // Set pointer to end of structure
         IntPtr iptrFaceDest = (IntPtr)((int)iptrLogFont + 
            cbLogFont);

         // Copy string to a character array.
         char [] achFace = strFace.ToCharArray(); 
         int cch = strFace.Length;
         if ( (cch+2) > LF_FACESIZE)
            cch = LF_FACESIZE;

         // Copy facename to unmanaged buffer
         Marshal.Copy(achFace, 0, iptrFaceDest, cch);

         hfont = CreateFontIndirect(iptrLogFont);

         NativeHeap.LocalFree(iptrLogFont);

         return hfont;
      }

   } // class
} // namespace
