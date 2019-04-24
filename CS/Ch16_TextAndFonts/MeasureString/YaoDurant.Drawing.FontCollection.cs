// YaoDurant.Drawing.FontCollection.cs - Enumerates available
// fonts with help of a Win32 DLL, FONTLIST.DLL
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace YaoDurant.Drawing
{
   /// <summary>
   /// Summary description for YaoDurant.
   /// </summary>
   public class FontCollection
   {
      public FontCollection()
      {
         //
         // TODO: Add constructor logic here
         //
         IntPtr hFontList = FontList_Create();
         int count = FontList_GetCount(hFontList);
         int i;
         string strFace;
         IntPtr ip;
         for (i = 0; i < count; i++)
         {
            ip = FontList_GetFace(hFontList, i);
            strFace = Marshal.PtrToStringUni(ip);
            m_alFaceNames.Add(strFace);
         }
         
         FontList_Destroy(hFontList);
      }

      // P/Invoke declarations for fontlist.dll
      [DllImport("fontlist.DLL")]
      public static extern IntPtr FontList_Create ();

      [DllImport("fontlist.DLL")]
      public static extern int FontList_GetCount (IntPtr hFontList);

      [DllImport("fontlist.DLL")]
      public static extern IntPtr FontList_GetFace (IntPtr hFontList, int iFace);

      [DllImport("fontlist.DLL")]
      public static extern int FontList_Destroy (IntPtr hFontList);
      
      // Count of available face names.
      public int Count
      {
         get { return m_alFaceNames.Count; }
      }

      private ArrayList m_alFaceNames = new ArrayList();
      
      public string this [int index]
      {
         get
         {
            if (index < 0 || index >= m_alFaceNames.Count)
               return string.Empty;
            else
               return (string)m_alFaceNames[index];
         }
      }

   } // class
} // namespace
