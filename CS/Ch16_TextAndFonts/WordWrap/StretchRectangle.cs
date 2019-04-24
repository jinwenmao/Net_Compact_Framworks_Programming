// StretchRectangle.cs - StretchRectangle object draw
// and moves a stretchable rectangle.
//
// Code from _Programming the .NET Compact Framework with C#_
// and _Programming the .NET Compact Framework with VB_
// (c) Copyright 2002-2004 Paul Yao and David Durant. 
// All rights reserved.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WordWrap
{
   /// <summary>
   /// Summary description for StretchRectangle.
   /// </summary>
   public class StretchRectangle
   {
      // Declarations needed to draw stretchable rectangle.
      [DllImport("coredll.dll")]
      public static extern IntPtr GetDC (IntPtr hWnd);
      [DllImport("coredll.dll")]
      public static extern int DrawFocusRect (IntPtr hDC, ref RECT lprc);
      [DllImport("coredll.dll")]
      public static extern int ReleaseDC (IntPtr hWnd, IntPtr hDC);
      [DllImport("coredll.dll")]
      public static extern IntPtr GetFocus ();
      [DllImport("coredll.dll")]
      public static extern IntPtr SetFocus (IntPtr hWnd);

      public struct RECT
      {
         public int left;
         public int top;
         public int right;
         public int bottom;
      };

      private RECT m_rect;
      private Point m_ptAnchor = new Point(0,0);
      private Control m_ctrl;
      private bool m_bStretching = false;
      public StretchRectangle()
      {
      }
      public void Init(int x, int y, Control ctrl)
      {
         m_ptAnchor.X = x;
         m_ptAnchor.Y = y;
         m_ctrl = ctrl;

         m_rect.left = x;
         m_rect.top = y; 
         m_rect.right = x;
         m_rect.bottom = y;

         m_bStretching = true;
      }
      
      public void Move(int x, int y)
      {
         if (!m_bStretching)
            return;

         // Remember window with focus.
         IntPtr hwndFocus = GetFocus();

         // Set focus to target window
         m_ctrl.Focus();
         IntPtr hwnd = GetFocus();

         // Get a DC from GDI
         IntPtr hdc = GetDC(hwnd);

         // Eraw previous rectangle.
         DrawFocusRect(hdc, ref m_rect);

         if (x != -1 && y != -1)  // (-1,-1) means erase only
         {
            if (x > m_ptAnchor.X)
            {
               m_rect.left = m_ptAnchor.X;
               m_rect.right = x;
            }
            else
            {
               m_rect.left = x;
               m_rect.right = m_ptAnchor.X;
            }
            
            if (y > m_ptAnchor.Y)
            {
               m_rect.top = m_ptAnchor.Y;
               m_rect.bottom = y;
            }
            else
            {
               m_rect.top = y;
               m_rect.bottom = m_ptAnchor.Y;
            }

            // Expand rectangle to match how final rectangle.
            m_rect.right++;
            m_rect.bottom++;

            // Draw new rectangle.
            DrawFocusRect(hdc, ref m_rect);
         }

         // Clean up.
         ReleaseDC(hwnd, hdc);
         
         SetFocus(hwndFocus);
      }
      
      public void Done()
      {
         Move(-1, -1);
         m_bStretching = false;
      }
   }
}
